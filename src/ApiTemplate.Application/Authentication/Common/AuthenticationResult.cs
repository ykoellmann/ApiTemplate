using ApiTemplate.Domain.User;

namespace ApiTemplate.Application.Authentication.Common;

public record AuthenticationResult(
    string Token,
    RefreshTokenEntity RefreshTokenEntity);