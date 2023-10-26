using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Errors;
using ApiTemplate.Domain.Users;
using ErrorOr;

namespace ApiTemplate.Application.Authentication.Queries.Login;

internal class LoginQueryHandler : IQueryHandler<LoginQuery, AuthenticationResult>
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
        if (await _userRepository.GetByEmailAsync(query.Email, cancellationToken) is not User user) 
            return Errors.Authentication.InvalidCredentials;

        if (!user.Password.Equals(query.Password)) 
            return Errors.Authentication.InvalidCredentials;

        var token = _jwtTokenProvider.GenerateToken(user);
        var refreshToken = RefreshToken.Create(user.Id);
        refreshToken = await _refreshTokenRepository.AddAsync(refreshToken, user.Id, cancellationToken);

        return new AuthenticationResult(token, refreshToken);
    }
}