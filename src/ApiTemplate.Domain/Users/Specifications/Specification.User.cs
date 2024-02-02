using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Domain.Users.Specifications;

public static partial class Specifications
{
    public static class User
    {
        public static UserIncludeAuthorizationSpecification IncludeAuthorization => new();
    }
}