using System.Linq.Expressions;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users.Specifications;

public partial class tmp : Specification<User, UserId, UserNameDto>
{
    protected override Expression<Func<User, UserNameDto>> Map()
    {
        throw new NotImplementedException();
    }
}