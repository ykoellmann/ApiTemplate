using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.User;

public class UserRepository : Repository<ApiTemplate.Domain.User.User, UserId>, IUserRepository
{
    private readonly ApiTemplateDbContext _dbContext;
    
    public UserRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<Domain.User.User> GetByIdAsync(UserId id, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<ApiTemplate.Domain.User.User> AddAsync(ApiTemplate.Domain.User.User entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return entity;
    }

    [Obsolete("This method is replaced by its overload")]
    public override Task<Domain.User.User> AddAsync(Domain.User.User entity, UserId userId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiTemplate.Domain.User.User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        return await _dbContext.Users.AnyAsync(u => u.Email == email);
    }
}