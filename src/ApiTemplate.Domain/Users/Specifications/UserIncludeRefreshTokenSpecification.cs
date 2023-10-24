using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Domain.Users.Specifications;

public class UserIncludeRefreshTokenSpecification : Specification<User, UserId>
{
    public override IQueryable<User> Specificate(IQueryable<User> query)
    {
        return query.Include(u => u.RefreshTokens);
    }
}