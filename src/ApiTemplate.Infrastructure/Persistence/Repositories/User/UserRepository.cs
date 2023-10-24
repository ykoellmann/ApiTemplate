using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Application.Users.Events;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using ApiTemplate.Infrastructure.Attributes;
using ApiTemplate.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.User;

[CacheDomainEvent(typeof(UpdatedEvent<,>), typeof(UserUpdatedEventHandler))]
public class UserRepository : Repository<Domain.Users.User, UserId>, IUserRepository
{
    private readonly ApiTemplateDbContext _dbContext;
    
    public UserRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<Domain.Users.User?> GetByIdAsync(UserId id, CancellationToken cancellationToken, Specification<Domain.Users.User, UserId> specification = null)
    {
        return await _dbContext.Users
            .Specificate(specification)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<Domain.Users.User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken: cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.AnyAsync(u => u.Email == email, cancellationToken: cancellationToken);
    }

    public async Task<Domain.Users.User> AddAsync(Domain.Users.User entity, CancellationToken cancellationToken)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return entity;
    }

    [Obsolete("This method is replaced by its overload")]
    public override async Task<Domain.Users.User> AddAsync(Domain.Users.User entity, UserId userId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}