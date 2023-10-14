using System.Security.Cryptography;
using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Errors;
using ApiTemplate.Domain.User;
using ErrorOr;
using MediatR;

namespace ApiTemplate.Application.Authentication.Commands.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenProvider jwtTokenProvider, IRefreshTokenRepository refreshTokenRepository)
    {
        _userRepository = userRepository;
        _jwtTokenProvider = jwtTokenProvider;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,
        CancellationToken cancellationToken)
    {
        //Check if user exists
        if (!await _userRepository.IsEmailUniqueAsync(command.Email, cancellationToken)) 
            return Errors.UserErrors.UserWithGivenEmailAlreadyExists;

        //Create user
        var user = Domain.User.User.Create(command.FirstName, command.LastName, command.Email, command.Password);
        await _userRepository.AddAsync(user, cancellationToken);

        //Generate token
        var token = _jwtTokenProvider.GenerateToken(user);
        
        var refreshToken = Domain.User.RefreshToken.Create(user.Id);

        refreshToken = await _refreshTokenRepository.AddAsync(refreshToken, user.Id, cancellationToken);

        return new AuthenticationResult(token, refreshToken);
    }
}