using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.User.ValueObjects;
using ApiTemplate.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.User.Specifications;

public class Test : Specification<Domain.User.User, UserId>
{
    private readonly ApiTemplateDbContext _dbContext;
    
    public Test(ApiTemplateDbContext dbContext)
    {
        _dbContext = dbContext;

        AddInclude(user => user.RefreshTokens)
            .AddThenInclude(token => token.User);
        AddInclude(user => user.RefreshTokens);

        AddOrderBy(user => user.Email)
            .AddThenBy(entity => entity.Id);
    }
}