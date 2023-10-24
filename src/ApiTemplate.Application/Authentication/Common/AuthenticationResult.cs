using ApiTemplate.Domain.Users;

namespace ApiTemplate.Application.Authentication.Common;

public record AuthenticationResult(
    string Token,
    RefreshToken RefreshToken);