using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using ErrorOr;
using MediatR;
using Errors = ApiTemplate.Domain.Users.Errors.Errors;

namespace ApiTemplate.Application.Authentication.Queries.Login;

internal class LoginQueryHandler : IQueryHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IPublisher _mediator;

    public LoginQueryHandler(IJwtTokenProvider jwtTokenProvider, IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, IPublisher mediator)
    {
        _jwtTokenProvider = jwtTokenProvider;
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _mediator = mediator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(query.Email, cancellationToken) is not User user) 
            return Errors.Authentication.InvalidCredentials;

        if (!user.Password.Equals(query.Password)) 
            return Errors.Authentication.InvalidCredentials;

        var token = _jwtTokenProvider.GenerateToken(user);
        var newRefreshToken = await _refreshTokenRepository.AddAsync(new RefreshToken(user.Id), user.Id, cancellationToken);

        return new AuthenticationResult(token, newRefreshToken);
    }
}