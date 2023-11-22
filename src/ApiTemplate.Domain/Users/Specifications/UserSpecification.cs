using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Domain.Users.Specifications;

public static class UserSpecification
{
    public static UserIncludeRefreshTokenSpecification IncludeRefreshToken => new();
}