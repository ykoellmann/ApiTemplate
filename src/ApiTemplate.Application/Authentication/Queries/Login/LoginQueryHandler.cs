using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.Specifications;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Errors = ApiTemplate.Domain.Users.Errors.Errors;

namespace ApiTemplate.Application.Authentication.Queries.Login;

internal class LoginQueryHandler : IQueryHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public LoginQueryHandler(IJwtTokenProvider jwtTokenProvider, IUserRepository userRepository,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _jwtTokenProvider = jwtTokenProvider;
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken ct)
    {
        var t = await _userRepository.GetListAsync(ct, Specifications.User.IncludeAuthorization);
        
        if (await _userRepository.GetByEmailAsync(query.Email, ct) is not User user)
            return Errors.Authentication.InvalidCredentials;

        if (!user.Password.Equals(query.Password))
            return Errors.Authentication.InvalidCredentials;
        
        user = await _userRepository.GetByIdAsync(user.Id, ct, Specifications.User.IncludeAuthorization);

        var token = _jwtTokenProvider.GenerateToken(user);
        var newRefreshToken =
            await _refreshTokenRepository.AddAsync(new RefreshToken(user.Id), user.Id, ct);

        return new AuthenticationResult(token, newRefreshToken);
    }
}