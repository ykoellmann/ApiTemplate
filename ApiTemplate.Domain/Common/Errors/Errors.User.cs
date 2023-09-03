using ErrorOr;

namespace ApiTemplate.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error UserWithGivenEmailAlreadyExists =>
            Error.Conflict("User.DuplicateEmail", "User with given Email already exists");
    }
}