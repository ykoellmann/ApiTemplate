using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Common.Specification.Include;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users.Specifications;

public partial class UserIncludeAuthorizationSpecification : Specification<User, UserId>
{
    protected override IIncludableSpecification<User> Include(IIncludableSpecification<User> includable)
    {
        return includable
            .Include(u => u.RefreshTokens)
            .Include(u => u.UserPermissions)
            .ThenInclude(up => up.Permission)
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .Include(u => u.UserPolicies)
            .ThenInclude(up => up.Policy);
    }
}