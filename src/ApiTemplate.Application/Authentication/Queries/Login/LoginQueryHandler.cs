using System.Security.Cryptography;
using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Errors;
using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;
using MediatR;

namespace ApiTemplate.Application.Authentication.Queries.Login;

internal class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public LoginQueryHandler(IJwtTokenProvider jwtTokenProvider, IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository)
    {
        _jwtTokenProvider = jwtTokenProvider;
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (_userRepository.GetByEmailAsync(query.Email).Result is not User user) 
            return Errors.Authentication.InvalidCredentials;

        if (!user.Password.Equals(query.Password)) 
            return Errors.Authentication.InvalidCredentials;

        var token = _jwtTokenProvider.GenerateToken(user);

        var refreshToken = RefreshToken.Create(user.Id);

        refreshToken = await _refreshTokenRepository.AddAsync(refreshToken, user.Id);

        return new AuthenticationResult(token, refreshToken);
    }
}