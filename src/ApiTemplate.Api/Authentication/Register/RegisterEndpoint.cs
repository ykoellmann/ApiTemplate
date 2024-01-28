using ApiTemplate.Api.Authentication.Request;
using ApiTemplate.Api.Authentication.Response;
using ApiTemplate.Api.Common.Endpoint;
using ApiTemplate.Application.Authentication.Commands.Register;
using ApiTemplate.Domain.Users.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Endpoint = ApiTemplate.Api.Common.Endpoint.Endpoint;

namespace ApiTemplate.Api.Authentication.Register;

public class RegisterEndpoint : Endpoint
    .WithRequest<RegisterRequest>
{
    public RegisterEndpoint(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
    }

    public override void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/register", HandleAsync)
            .AllowAnonymous()
            .RequireRateLimiting("sliding");
    }

    public override async Task<IResult> HandleAsync(ISender mediator, IMapper mapper, RegisterRequest request,
        CancellationToken ct = default)
    {
        var command = mapper.Map<RegisterCommand>(request);

        var authResult = await mediator.Send(command, ct);
        
        return authResult.Match(
            authResult => Results.Ok(mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}