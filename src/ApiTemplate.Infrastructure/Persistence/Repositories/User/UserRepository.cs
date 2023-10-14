using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Application.User.Events;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.User.ValueObjects;
using ApiTemplate.Infrastructure.Attributes;
using ApiTemplate.Infrastructure.Extensions;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.User;

[CacheDomainEvent(typeof(UpdatedEvent<,>), typeof(UserUpdatedEventHandler))]
public class UserRepository : Repository<ApiTemplate.Domain.User.User, UserId>, IUserRepository
{
    private readonly ApiTemplateDbContext _dbContext;
    
    public UserRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<Domain.User.User?> GetByIdAsync(UserId id, CancellationToken cancellationToken, Specification<Domain.User.User, UserId> specification = null)
    {
        return await _dbContext.Users
            .Specificate(specification)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<ApiTemplate.Domain.User.User> AddAsync(ApiTemplate.Domain.User.User entity, CancellationToken cancellationToken)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return entity;
    }

    [Obsolete("This method is replaced by its overload")]
    public override async Task<Domain.User.User> AddAsync(Domain.User.User entity, UserId userId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiTemplate.Domain.User.User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken: cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.AnyAsync(u => u.Email == email, cancellationToken: cancellationToken);
    }
}