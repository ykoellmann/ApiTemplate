using ApiTemplate.Api.Authentication.Request;
using ApiTemplate.Api.Authentication.Response;
using ApiTemplate.Api.Common.Controllers;
using ApiTemplate.Application.Authentication.Commands.Refresh;
using ApiTemplate.Application.Authentication.Commands.Register;
using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Authentication.Queries.Login;
using ApiTemplate.Domain.Users.ValueObjects;
using Hangfire;
using Hangfire.States;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Errors = ApiTemplate.Domain.Users.Errors.Errors;

namespace ApiTemplate.Api.Authentication;

[Route("api/authentication")]
[Authorize]
public class AuthenticationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly IBackgroundJobClient _backgroundJobClient;

    public AuthenticationController(ISender mediator, IMapper mapper, IBackgroundJobClient backgroundJobClient)
    {
        _mediator = mediator;
        _mapper = mapper;
        _backgroundJobClient = backgroundJobClient;
    }

    [HttpPost("register")]
    [EnableRateLimiting("sliding")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterRequest registerRequest, CancellationToken ct)
    {
        var command = _mapper.Map<RegisterCommand>(registerRequest);

        var authResult = await _mediator.Send(command, ct);

        return authResult.Match(
            SetRefreshToken,
            Problem);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest loginRequest, CancellationToken ct)
    {
        var query = _mapper.Map<LoginQuery>(loginRequest);

        var authResult = await _mediator.Send(query, ct);

        return authResult.Match(
            SetRefreshToken,
            Problem);
    }

    [HttpPost("token/refresh")]
    public async Task<IActionResult> RefreshToken()
    {
        var tokenToRefresh = Request.Cookies["refreshToken"];

        if (string.IsNullOrEmpty(tokenToRefresh))
            return Problem(Errors.Authentication.InvalidRefreshToken);

        var authResult = await _mediator.Send(new RefreshTokenCommand(tokenToRefresh, UserId));

        return authResult.Match(
            SetRefreshToken,
            Problem);
    }

    private IActionResult SetRefreshToken(AuthenticationResult authResult)
    {
        var refreshToken = authResult.RefreshToken;

        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = refreshToken.Expires
        };

        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

        return Ok(_mapper.Map<AuthenticationResponse>(authResult));
    }

    [HttpGet("test")]
    [AllowAnonymous]
    public IActionResult Test(CancellationToken ct)
    {
        _backgroundJobClient.Enqueue((ISender sender) => sender.Send(new RefreshTokenCommand("", new UserId()), new CancellationToken()));
        return Ok("Test");
    }
}