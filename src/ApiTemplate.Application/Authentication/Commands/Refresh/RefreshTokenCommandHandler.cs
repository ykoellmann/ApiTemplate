﻿using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Application.Common.Interfaces.Security;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.Specifications;
using ErrorOr;
using Errors = ApiTemplate.Domain.Users.Errors.Errors;

namespace ApiTemplate.Application.Authentication.Commands.Refresh;

public class RefreshTokenCommandHandler : ICommandHandler<RefreshTokenCommand, AuthenticationResult>
{
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;

    public RefreshTokenCommandHandler(IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository,
        IJwtTokenProvider jwtTokenProvider)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
        _jwtTokenProvider = jwtTokenProvider;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RefreshTokenCommand request,
        CancellationToken ct)
    {
        //Get user with userId and check if given refresh token is users last refresh token. Only one can be valid for one user at a time.
        var user = await _userRepository.GetByIdAsync(request.UserId, ct,
            Specifications.User.IncludeAuthorization);

        if (user is null)
            return Errors.User.UserNotFound;

        if (!user.HasActiveRefreshToken)
            return Errors.Authentication.RefreshTokenExpired;

        if (user.ActiveRefreshToken!.Token != request.TokenToRefresh)
            return Errors.Authentication.InvalidRefreshToken;

        var newRefreshToken =
            await _refreshTokenRepository.AddAsync(new RefreshToken(user.Id), user.Id, ct);
        var jwtToken = _jwtTokenProvider.GenerateToken(user);

        return new AuthenticationResult(jwtToken, newRefreshToken);
    }
}