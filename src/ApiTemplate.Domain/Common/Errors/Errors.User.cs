using ErrorOr;

namespace ApiTemplate.Domain.Common.Errors;

public static partial class Errors
{
    public static class UserErrors
    {
        public static Error UserWithGivenEmailAlreadyExists =>
            Error.Conflict("User.DuplicateEmail", "User with given Email already exists");
        public static Error UserDoesNotExist =>
            Error.Conflict("User.DoesNotExist", "User does not exists");
    }
}