﻿using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.Users;

public class RefreshTokenRepository : Repository<RefreshToken, RefreshTokenId>, IRefreshTokenRepository
{
    private readonly ApiTemplateDbContext _dbContext;

    public RefreshTokenRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<RefreshToken> AddAsync(RefreshToken entity, UserId userId,
        CancellationToken cancellationToken)
    {
        await _dbContext.RefreshTokens
            .Where(rt => rt.UserId == userId)
            .ExecuteUpdateAsync(s => 
                s.SetProperty(rt => rt.Disabled, true), 
                cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return await base.AddAsync(entity, userId, cancellationToken);
    }
}