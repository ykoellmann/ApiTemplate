using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.User;

public class RefreshTokenRepository : Repository<RefreshToken, RefreshTokenId>, IRefreshTokenRepository
{
    private ApiTemplateDbContext _dbContext;
    
    public RefreshTokenRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RefreshToken> Add(RefreshToken entity, UserId userId)
    {
        await _dbContext.RefreshTokens
            .Where(rt => rt.UserId == userId)
            .ExecuteUpdateAsync(s => s.SetProperty(rt => rt.Disabled, true));
        await _dbContext.SaveChangesAsync();
        
        return await base.Add(entity, userId);
    }
}