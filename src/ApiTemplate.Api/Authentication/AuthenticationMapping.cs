using ApiTemplate.Application.Authentication.Commands.Register;
using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Authentication.Queries.Login;
using ApiTemplate.Contracts.Authentication;
using Mapster;

namespace ApiTemplate.Api.Authentication;

internal class AuthenticationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>()
            .MapToConstructor(true);

        config.NewConfig<LoginRequest, LoginQuery>()
            .MapToConstructor(true);

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .MapToConstructor(true);
    }
}