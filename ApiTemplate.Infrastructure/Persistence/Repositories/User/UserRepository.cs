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
    
    public async Task<ErrorOr<ApiTemplate.Domain.User.User>> Add(ApiTemplate.Domain.User.User entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return entity;
    }

    [Obsolete("This method is replaced by its overload")]
    public Task<ErrorOr<ApiTemplate.Domain.User.User>> Add(ApiTemplate.Domain.User.User entity, UserId userId)
    {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<ApiTemplate.Domain.User.User>?> GetByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}