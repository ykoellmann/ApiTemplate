using ApiTemplate.Application.Authentication.Commands.RefreshToken;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using ApiTemplate.Application.Authentication.Commands.Register;
using ApiTemplate.Application.Authentication.Queries.Login;
using ApiTemplate.Contracts.Authentication;
using ApiTemplate.Domain.Common.Errors;
using ApiTemplate.Domain.User;

namespace ApiTemplate.Api.Controllers;

[Route("api/auth"), Authorize]
public class AuthenticationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register"), EnableRateLimiting("sliding"), AllowAnonymous]
    public async Task<IActionResult> Register(RegisterRequest registerRequest, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<RegisterCommand>(registerRequest);

        var authResult = await _mediator.Send(command, cancellationToken);

        if (authResult.IsError && authResult.FirstError == Errors.User.UserWithGivenEmailAlreadyExists)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

        return authResult.Match(
            authResult =>
            {
                SetRefreshToken(authResult.RefreshToken).Wait();
                return Ok(_mapper.Map<AuthenticationResponse>(authResult));
            },
            errors => Problem(errors));
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var query = _mapper.Map<LoginQuery>(loginRequest);

        var authResult = await _mediator.Send(query, cancellationToken);
        
        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

        return authResult.Match(
            authResult =>
            {
                SetRefreshToken(authResult.RefreshToken).Wait();
                return Ok(_mapper.Map<AuthenticationResponse>(authResult));
            },
            errors => Problem(errors));
    }
    
    [HttpPost("token/refresh")]
    public async Task<IActionResult> RefreshToken()
    {
        var tokenToRefresh = Request.Cookies["refreshToken"];
        
        if (string.IsNullOrEmpty(tokenToRefresh))
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: Errors.Authentication.InvalidRefreshToken.Description);

        var authResult = await _mediator.Send(new RefreshTokenCommand(tokenToRefresh, UserId));

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidRefreshToken)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

        return authResult.Match(
            authResult =>
            {
                SetRefreshToken(authResult.RefreshToken).Wait();
                return Ok(_mapper.Map<AuthenticationResponse>(authResult));
            },
            errors => Problem(errors));
    }

    private async Task SetRefreshToken(RefreshToken refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = refreshToken.Expires,
        };
        
        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }
}