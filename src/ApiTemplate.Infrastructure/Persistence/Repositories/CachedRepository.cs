using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;
using ApiTemplate.Infrastructure.Extensions;
using ErrorOr;
using Microsoft.Extensions.Caching.Distributed;

namespace ApiTemplate.Infrastructure.Persistence.Repositories;

public class CachedRepository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    public readonly TimeSpan CacheExpiration;
    private readonly IRepository<TEntity, TId> _decorated;

    protected readonly IDistributedCache Cache;

    public async Task<string> EntityCacheKeyAsync(string usage) => 
        $"{typeof(TEntity).Name}:{usage}";

    public async Task<string> EntityValueCacheKeyAsync(string usage, string value) =>
        $"{typeof(TEntity).Name}:{usage}:{value}";

    public CachedRepository(IRepository<TEntity, TId> decorated, IDistributedCache cache,
        int cacheExpirationMinutes = 10)
    {
        _decorated = decorated;
        Cache = cache;
        CacheExpiration = TimeSpan.FromMinutes(cacheExpirationMinutes) + TimeSpan.FromSeconds(new Random().Next(0, 60));
    }

    public virtual async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken,
        Specification<TEntity, TId> specification = null)
    {
        var cacheKey = await EntityCacheKeyAsync(nameof(GetListAsync));
        return await Cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);

            return await _decorated.GetListAsync(cancellationToken, specification);
        });
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken,
        Specification<TEntity, TId> specification = null)
    {
        var cacheKey = await EntityValueCacheKeyAsync(nameof(GetByIdAsync), id.Value.ToString());

        return await Cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);

            return await _decorated.GetByIdAsync(id, cancellationToken, specification);
        });
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, UserId userId, CancellationToken cancellationToken)
    {
        entity.AddDomainEventAsync(new CreatedEvent<TEntity, TId>(entity));

        var addedEntity = await _decorated.AddAsync(entity, userId, cancellationToken);
        var cacheKey = await EntityValueCacheKeyAsync(nameof(GetByIdAsync), addedEntity.Id.Value.ToString());

        return await Cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);

            return addedEntity;
        });
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        entity.AddDomainEventAsync(new UpdatedEvent<TEntity, TId>(entity));

        var updatedEntity = await _decorated.UpdateAsync(entity, cancellationToken);
        var cacheKey = await EntityValueCacheKeyAsync(nameof(GetByIdAsync), updatedEntity.Id.Value.ToString());

        return await Cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);

            return updatedEntity;
        });
    }

    public virtual async Task<Deleted> DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        var entity = await _decorated.GetByIdAsync(id, cancellationToken);

        entity.AddDomainEventAsync(new DeletedEvent<TEntity, TId>(entity));

        return await _decorated.DeleteAsync(id, cancellationToken);
    }

    public async Task ClearCacheAsync(IAsyncEnumerable<string> cacheKeys = null)
    {
        await foreach (var cacheKey in cacheKeys)
        {
            await Cache.RemoveAsync(cacheKey);
        }
    }
}