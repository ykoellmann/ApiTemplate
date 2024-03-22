using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ApiTemplate.Domain.Users.Specifications;

public class UserIncludeAuthorizationSpecificationOld : SpecificationOld<User, UserId>
{
    public override IQueryable<User> Specificate(IQueryable<User> query)
    {
        return query.Include(u => u.RefreshTokens)
            .ThenInclude(x => x.User)
            .ThenInclude(x => x.RefreshTokens)
            .Include(u => u.UserPermissions)
            .ThenInclude(up => up.Permission)
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .Include(u => u.UserPolicies)
            .ThenInclude(up => up.Policy);
    }
}