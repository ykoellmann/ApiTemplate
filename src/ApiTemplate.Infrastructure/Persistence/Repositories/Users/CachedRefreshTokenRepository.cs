using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.Extensions.Caching.Distributed;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.Users;

public class CachedRefreshTokenRepository : CachedRepository<RefreshToken, RefreshTokenId, IRefreshTokenDto>, IRefreshTokenRepository
{
    public CachedRefreshTokenRepository(IRefreshTokenRepository decorated, IDistributedCache cache) :
        base(decorated, cache)
    {
    }

    protected override async IAsyncEnumerable<string> GetCacheKeysAsync<TChanged>(TChanged changedEvent)
    {
        yield break;
    }
}