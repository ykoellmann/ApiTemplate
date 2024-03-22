using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Common.Specification.Include;
using ApiTemplate.Domain.Common.Specification.Order;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users.Specifications;

public class UserIncludeAuthorizationSpecification : Specification<User, UserId>
{
    public override IOrderedSpecification<User> Order()
    {
        return OrderedSpecification<User>
            .OrderByDescending(x => x.RefreshTokens.Single().Expired);
    }

    public override IIncludableSpecification<User> Include()
    {
        return IncludableSpecification<User>
            .Include(u => u.RefreshTokens)
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