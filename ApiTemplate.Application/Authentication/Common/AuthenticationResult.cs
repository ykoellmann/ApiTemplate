using ApiTemplate.Domain.User;

namespace ApiTemplate.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);