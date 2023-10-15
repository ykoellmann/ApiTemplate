using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Domain.User.Specifications;

public class UserIncludeRefreshTokenSpecification : Specification<UserEntity, UserId>
{
    public override IQueryable<UserEntity> Specificate(IQueryable<UserEntity> query)
    {
        return query.Include(u => u.RefreshTokens);
    }
}