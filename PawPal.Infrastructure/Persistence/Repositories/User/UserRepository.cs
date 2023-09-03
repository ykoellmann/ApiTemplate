using ErrorOr;
using Microsoft.EntityFrameworkCore;
using PawPal.Application.Common.Interfaces.Persistence;
using PawPal.Domain.User;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Repositories.User;

public class UserRepository : Repository<Domain.User.User, UserId>, IUserRepository
{
    private readonly PawPalDbContext _dbContext;
    
    public UserRepository(PawPalDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ErrorOr<Domain.User.User>> Add(Domain.User.User entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return entity;
    }

    [Obsolete("This method is replaced by its overload")]
    public Task<ErrorOr<Domain.User.User>> Add(Domain.User.User entity, UserId userId)
    {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<Domain.User.User>?> GetByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}