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

    public async Task<RefreshToken> AddAsync(RefreshToken entity, UserId userId, CancellationToken cancellationToken)
    {
        await _dbContext.RefreshTokens
            .Where(rt => rt.UserId == userId)
            .ExecuteUpdateAsync(s => s.SetProperty(rt => rt.Disabled, true), cancellationToken: cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return await base.AddAsync(entity, userId, cancellationToken);
    }
}