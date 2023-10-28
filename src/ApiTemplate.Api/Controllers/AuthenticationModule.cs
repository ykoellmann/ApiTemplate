using ApiTemplate.Application.Authentication.Commands.Refresh;
using ApiTemplate.Application.Authentication.Commands.Register;
using ApiTemplate.Application.Authentication.Queries.Login;
using ApiTemplate.Contracts.Authentication;
using ApiTemplate.Domain.Common.Errors;
using ApiTemplate.Domain.Users;
using MapsterMapper;
using MediatR;

namespace ApiTemplate.Api.Controllers;

public class AuthenticationModule : ApiModule
{
    public AuthenticationModule() : base("authentication")
    {
        
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/register",
            async (ISender sender, IMapper mapper, HttpContext httpContext, RegisterRequest registerRequest,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<RegisterCommand>(registerRequest);

                var authResult = await sender.Send(command, cancellationToken);

                if (authResult.IsError && authResult.FirstError == Errors.User.UserWithGivenEmailAlreadyExists)
                    return Results.Problem(statusCode: StatusCodes.Status401Unauthorized,
                        title: authResult.FirstError.Description);

                return authResult.Match(
                    authResult =>
                    {
                        SetRefreshToken(authResult.RefreshToken, httpContext).Wait();
                        return Results.Ok(mapper.Map<AuthenticationResponse>(authResult));
                    },
                    errors => Problem(errors, httpContext));
            });
        
        app.MapPost("/login",
            async (ISender sender, IMapper mapper, HttpContext httpContext, LoginRequest loginRequest,
                CancellationToken cancellationToken) =>
            {
                var query = mapper.Map<LoginQuery>(loginRequest);

                var authResult = await sender.Send(query, cancellationToken);
        
                if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
                    return Results.Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

                return authResult.Match(
                    authResult =>
                    {
                        SetRefreshToken(authResult.RefreshToken, httpContext).Wait();
                        return Results.Ok(mapper.Map<AuthenticationResponse>(authResult));
                    },
                    errors => Problem(errors, httpContext));
            });

        app.MapPost("token/refresh", async (ISender sender, IMapper mapper, HttpContext httpContext, 
            CancellationToken cancellationToken) =>
        {
            var tokenToRefresh = httpContext.Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(tokenToRefresh))
                return Results.Problem(statusCode: StatusCodes.Status401Unauthorized,
                    title: Errors.Authentication.InvalidRefreshToken.Description);

            var authResult = await sender.Send(new RefreshTokenCommand(tokenToRefresh, UserId(httpContext)), cancellationToken);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidRefreshToken)
                return Results.Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

            return authResult.Match(
                authResult =>
                {
                    SetRefreshToken(authResult.RefreshToken, httpContext).Wait();
                    return Results.Ok(mapper.Map<AuthenticationResponse>(authResult));
                },
                errors => Problem(errors, httpContext));
        });
    }
    
    private async Task SetRefreshToken(RefreshToken refreshToken, HttpContext httpContext)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = refreshToken.Expires,
        };
        
        httpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }
}