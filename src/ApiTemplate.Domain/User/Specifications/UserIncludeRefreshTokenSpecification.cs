using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Domain.User.Specifications;

public class UserIncludeRefreshTokenSpecification : Specification<User, UserId>
{
    public override IQueryable<User> Specificate(IQueryable<User> query)
    {
        return query.Include(u => u.RefreshTokens);
    }
}