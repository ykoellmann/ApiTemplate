using Mapster;
using PawPal.Application.Authentication.Commands.Register;
using PawPal.Application.Authentication.Common;
using PawPal.Application.Authentication.Queries.Login;
using PawPal.Contracts.Authentication;

namespace PawPal.Api.Common.Mapping;

public class AuthenticationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>()
            .MapToConstructor(true);

        config.NewConfig<LoginRequest, LoginQuery>()
            .MapToConstructor(true);

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id , src => src.User.Id.Value)
            .Map(dest => dest, src => src.User)
            .Map(dest => dest.Token, src => src.Token)
            .MapToConstructor(true);
    }
}