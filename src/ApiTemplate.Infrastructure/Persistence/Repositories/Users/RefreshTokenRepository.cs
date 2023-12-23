using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.Users;

public class RefreshTokenRepository : Repository<RefreshToken, RefreshTokenId, IRefreshTokenDto>,
    IRefreshTokenRepository
{
    private readonly ApiTemplateDbContext _dbContext;

    public RefreshTokenRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    //toDo: Cache invalidation
    public override async Task<RefreshToken> AddAsync(RefreshToken entity, UserId userId,
        CancellationToken cancellationToken)
    {
        var refreshTokens = await _dbContext.RefreshTokens
            .Where(rt => rt.UserId == userId && !rt.Disabled)
            .ToListAsync(cancellationToken);

        refreshTokens.ForEach(async rt => 
            await entity.AddDomainEventAsync(new DeletedEvent<RefreshToken, RefreshTokenId>(rt)));
        
        await _dbContext.RefreshTokens
            .Where(rt => rt.UserId == userId && !rt.Disabled)
            .ExecuteUpdateAsync(s =>
                    s.SetProperty(rt => rt.Disabled, true),
                cancellationToken);

        return await base.AddAsync(entity, userId, cancellationToken);
    }
}