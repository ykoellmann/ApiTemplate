using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Application.Users.Events;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using ApiTemplate.Infrastructure.Cache.CustomCacheAttributes;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.Users;

[CustomClearCacheEvent(typeof(UserCreatedEvent))]
public class UserRepository : Repository<User, UserId, IUserDto>, IUserRepository
{
    private readonly ApiTemplateDbContext _dbContext;

    public UserRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken: cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.AllAsync(u => u.Email != email, cancellationToken: cancellationToken);
    }

    public async Task<User> AddAsync(User entity, CancellationToken cancellationToken)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    [Obsolete("This method is replaced by its overload")]
    public override async Task<User> AddAsync(User entity, UserId userId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}