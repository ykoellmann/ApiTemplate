using System.Linq.Expressions;
using ApiTemplate.Domain.Common.Specification.Include;
using ApiTemplate.Domain.Common.Specification.Order;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Common.Specification;

public class tmp : Specification<User, UserId, UserNameDtoOld>
{
    protected override bool AsNoTracking => false;

    public override Expression<Func<User, UserNameDtoOld>> Map() =>
        user => new UserNameDtoOld(user.Id, user.FirstName, user.LastName);

    public override IIncludableSpecification<User>? Include()
    {
        return IncludableSpecification<User>
            .Include(user => user.RefreshTokens)
            .ThenInclude(rt => rt.User)
            .ThenInclude(u => u.UserPolicies);
    }

    public override IOrderedSpecification<User> Order()
    {
        return OrderedSpecification<User>
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);
    }
}