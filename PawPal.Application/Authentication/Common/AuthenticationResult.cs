using PawPal.Domain.User;

namespace PawPal.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);