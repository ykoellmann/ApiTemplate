using ApiTemplate.Application.Common.Events;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.Users;

public class RefreshTokenRepository : Repository<RefreshToken, RefreshTokenId>,
    IRefreshTokenRepository
{
    private readonly ApiTemplateDbContext _dbContext;

    public RefreshTokenRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<RefreshToken> AddAsync(RefreshToken entity, UserId userId,
        CancellationToken ct)
    {
        var refreshTokens = await _dbContext.RefreshTokens
            .Where(rt => rt.UserId == userId && !rt.Disabled)
            .ToListAsync(ct);

        refreshTokens.ForEach(async rt =>
        {
            rt.Disabled = true;
            await entity.AddDomainEventAsync(new ClearCacheEvent<RefreshToken, RefreshTokenId>(rt));
        });
        
        return await base.AddAsync(entity, userId, ct);
    }
}