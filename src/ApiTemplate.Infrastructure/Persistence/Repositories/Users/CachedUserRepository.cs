using ApiTemplate.Application.Common.Events;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using ApiTemplate.Infrastructure.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.Users;

public class CachedUserRepository : CachedRepository<User, UserId>, IUserRepository
{
    private readonly IUserRepository _decorated;
    private readonly IDistributedCache _cache;

    public CachedUserRepository(IUserRepository decorated, IDistributedCache cache) : base(decorated, cache)
    {
        _decorated = decorated;
        _cache = cache;
    }

    protected override async IAsyncEnumerable<CacheKey<User>> GetCacheKeysAsync<TChanged>(TChanged changedEvent)
    {
        yield return new CacheKey<User>(nameof(GetByEmailAsync),
            changedEvent.Changed.Email);
        yield return new CacheKey<User>(nameof(IsEmailUniqueAsync),
            changedEvent.Changed.Email);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct)
    {
        var cacheKey = new CacheKey<User>(nameof(GetByEmailAsync), email);

        return await _cache.GetOrCreateAsync(cacheKey, CacheExpiration,
            _ => _decorated.GetByEmailAsync(email, ct));
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken ct)
    {
        var cacheKey = new CacheKey<User>(nameof(IsEmailUniqueAsync), email);

        return await _cache.GetOrCreateAsync(cacheKey, CacheExpiration,
            _ => _decorated.IsEmailUniqueAsync(email, ct));
    }

    public async Task<User> AddAsync(User entity, CancellationToken ct)
    {
        entity.AddDomainEvent(new ClearCacheEvent<User, UserId>(entity));

        var addedEntity = await _decorated.AddAsync(entity, ct);
        var cacheKey = new CacheKey<User>(nameof(GetByIdAsync), addedEntity.Id.Value.ToString());

        return await Cache.GetOrCreateAsync(cacheKey, CacheExpiration, async _ => addedEntity);
    }

    [Obsolete("This method is replaced by its overload")]
    public override async Task<User> AddAsync(User entity, UserId userId,
        CancellationToken ct)
    {
        throw new NotImplementedException("This method is replaced by its overload");
    }
}