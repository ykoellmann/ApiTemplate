using ApiTemplate.Application.Common.Events.Created;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using ApiTemplate.Infrastructure.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.Users;

public class CachedUserRepository : CachedRepository<User, UserId, IUserDto>, IUserRepository
{
    private readonly IUserRepository _decorated;
    private readonly IDistributedCache _cache;

    public CachedUserRepository(IUserRepository decorated, IDistributedCache cache) : base(decorated, cache)
    {
        _decorated = decorated;
        _cache = cache;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var cacheKey = await EntityValueCacheKeyAsync(nameof(GetByEmailAsync), email);

        return await _cache.GetOrCreateAsync(cacheKey, CacheExpiration,
            _ => _decorated.GetByEmailAsync(email, cancellationToken));
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
    {
        var cacheKey = await EntityValueCacheKeyAsync(nameof(IsEmailUniqueAsync), email);

        return await _cache.GetOrCreateAsync(cacheKey, CacheExpiration,
            _ => _decorated.IsEmailUniqueAsync(email, cancellationToken));
    }

    public async Task<User> AddAsync(User entity, CancellationToken cancellationToken)
    {
        await entity.AddDomainEventAsync(new CreatedEvent<User, UserId>(entity));

        var addedEntity = await _decorated.AddAsync(entity, cancellationToken);
        var cacheKey = await EntityValueCacheKeyAsync(nameof(GetByIdAsync), addedEntity.Id.Value.ToString());

        return await Cache.GetOrCreateAsync(cacheKey, CacheExpiration, async _ => addedEntity);
    }

    [Obsolete("This method is replaced by its overload")]
    public override async Task<User> AddAsync(User entity, UserId userId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}