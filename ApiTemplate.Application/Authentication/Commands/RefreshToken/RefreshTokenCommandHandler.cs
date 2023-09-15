using System.Security.Cryptography;
using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace ApiTemplate.Application.Authentication.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenProvider _jwtTokenProvider;

    public RefreshTokenCommandHandler(IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository, IJwtTokenProvider jwtTokenProvider)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
        _jwtTokenProvider = jwtTokenProvider;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        //Get user with userId and check if given refresh token is users last refresh token. Only one can be valid for one user at a time.
        var user = await _userRepository.GetById(request.UserID);

        if (user is null)
            return Errors.User.UserDoesNotExist;

        if (user.ActiveRefreshToken.Expired)
            return Errors.Authentication.RefreshTokenExpired;
        
        if (user.ActiveRefreshToken.Token != request.TokenToRefresh)
            return Errors.Authentication.InvalidRefreshToken;
        
        
        var newRefreshToken = Domain.User.RefreshToken.Create(
            Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)), 
            DateTime.Now.AddMinutes(1),
            user.Id);
        
        newRefreshToken = await _refreshTokenRepository.Add(newRefreshToken, user.Id);
        var jwtToken = _jwtTokenProvider.GenerateToken(user);
        
        return new AuthenticationResult(jwtToken, newRefreshToken);
    }
}