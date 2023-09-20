using ErrorOr;

namespace ApiTemplate.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials =>
            Error.Conflict("Authentication.InvalidCredentials", "Invalid credentials");
        public static Error InvalidRefreshToken =>
            Error.Conflict("Authentication.InvalidRefreshToken", "Invalid refresh token");
        public static Error RefreshTokenExpired =>
            Error.Conflict("Authentication.RefreshTokenExpired", "Refresh token expired");
    }
}