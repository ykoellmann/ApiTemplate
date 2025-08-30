using System.Linq.Expressions;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users.Specifications;

public partial class UserNameDtoSpecification : Specification<User, UserId, UserNameDto>
{
    protected override Expression<Func<User, UserNameDto>> Map()
    {
        return user => new UserNameDto(user.Id, user.FirstName, user.LastName);
    }
}