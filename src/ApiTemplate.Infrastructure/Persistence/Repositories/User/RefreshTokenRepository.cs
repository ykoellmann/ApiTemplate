using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.User;

public class RefreshTokenRepository : Repository<RefreshTokenEntity, RefreshTokenId>, IRefreshTokenRepository
{
    private readonly ApiTemplateDbContext _dbContext;
    
    public RefreshTokenRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<RefreshTokenEntity> AddAsync(RefreshTokenEntity entity, UserId userId, CancellationToken cancellationToken)
    {
        await _dbContext.RefreshTokens
            .Where(rt => rt.UserId == userId)
            .ExecuteUpdateAsync(s => s.SetProperty(rt => rt.Disabled, true), cancellationToken: cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return await base.AddAsync(entity, userId, cancellationToken);
    }
}