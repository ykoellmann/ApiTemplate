using ErrorOr;

namespace ApiTemplate.Domain.Users.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials =>
            Error.Unauthorized("Authentication.InvalidCredentials", "Invalid credentials");
        public static Error InvalidRefreshToken =>
            Error.Unauthorized("Authentication.InvalidRefreshToken", "Invalid refresh token");
        public static Error RefreshTokenExpired =>
            Error.Unauthorized("Authentication.RefreshTokenExpired", "Refresh token expired");
    }
}