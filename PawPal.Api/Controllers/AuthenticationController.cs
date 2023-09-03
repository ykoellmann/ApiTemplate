using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PawPal.Api.Controllers.Generic.Interfaces;
using PawPal.Application.Authentication.Commands.Register;
using PawPal.Application.Authentication.Queries.Login;
using PawPal.Contracts.Authentication;
using PawPal.Domain.Common.Errors;

namespace PawPal.Api.Controllers;

[Route("api/auth"), AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register"), EnableRateLimiting("sliding")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var command = _mapper.Map<RegisterCommand>(registerRequest);

        var authResult = await _mediator.Send(command);

        if (authResult.IsError && authResult.FirstError == Errors.User.UserWithGivenEmailAlreadyExists)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var query = _mapper.Map<LoginQuery>(loginRequest);

        var authResult = await _mediator.Send(query);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}