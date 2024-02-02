using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.Specifications;
using ApiTemplate.Domain.Users.ValueObjects;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Errors = ApiTemplate.Domain.Users.Errors.Errors;

namespace ApiTemplate.Application.Authentication.Commands.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenProvider jwtTokenProvider,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _userRepository = userRepository;
        _jwtTokenProvider = jwtTokenProvider;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,
        CancellationToken ct)
    {
        //Check if user exists
        if (!await _userRepository.IsEmailUniqueAsync(command.Email, ct))
            return Errors.User.UserWithGivenEmailAlreadyExists;

        //Create user
        var user = new User(command.FirstName, command.LastName, command.Email, command.Password);
        await _userRepository.AddAsync(user, ct);
        
        user = await _userRepository.GetByIdAsync(user.Id, ct, Specifications.User.IncludeAuthorization);

        //Generate token
        var token = _jwtTokenProvider.GenerateToken(user);
        var newRefreshToken =
            await _refreshTokenRepository.AddAsync(new RefreshToken(user.Id), user.Id, ct);

        return new AuthenticationResult(token, newRefreshToken);
    }
}