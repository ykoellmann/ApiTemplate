using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.Extensions.Caching.Distributed;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.Users;

public class CachedRefreshTokenRepository : CachedRepository<RefreshToken, RefreshTokenId>, IRefreshTokenRepository
{
    public CachedRefreshTokenRepository(IRepository<RefreshToken, RefreshTokenId> decorated, IDistributedCache cache,
        int cacheExpirationMinutes = 10) : base(decorated, cache, cacheExpirationMinutes)
    {
    }
}