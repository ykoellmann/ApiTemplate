using ApiTemplate.Application.Common.Events;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;
using ApiTemplate.Infrastructure.Extensions;
using ErrorOr;
using Microsoft.Extensions.Caching.Distributed;

namespace ApiTemplate.Infrastructure.Persistence.Repositories;

public abstract class CachedRepository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>
{
    public readonly TimeSpan CacheExpiration;
    private readonly IRepository<TEntity, TId> _decorated;

    protected readonly IDistributedCache Cache;

    public CachedRepository(IRepository<TEntity, TId> decorated, IDistributedCache cache,
        int cacheExpirationMinutes = 10)
    {
        _decorated = decorated;
        Cache = cache;
        CacheExpiration = TimeSpan.FromMinutes(cacheExpirationMinutes) + TimeSpan.FromSeconds(new Random().Next(0, 60));
    }

    #region Caching

    public async Task ClearCacheAsync<TChanged>(TChanged changedEvent)
        where TChanged : ClearCacheEvent<TEntity, TId>
    {
        await foreach (string cacheKey in GetBaseCacheKeysAsync(changedEvent))
        {
            await Cache.RemoveAsync(cacheKey);
        }
    }

    private async IAsyncEnumerable<CacheKey<TEntity>> GetBaseCacheKeysAsync<TChanged>(TChanged changedEvent)
        where TChanged : ClearCacheEvent<TEntity, TId>
    {
        yield return new CacheKey<TEntity>(nameof(GetByIdAsync),
            changedEvent.Changed.Id.Value.ToString());
        yield return new CacheKey<TEntity>(nameof(GetListAsync));

        await foreach (var cacheKey in GetCacheKeysAsync(changedEvent))
        {
            yield return cacheKey;
        }
    }

    protected abstract IAsyncEnumerable<CacheKey<TEntity>> GetCacheKeysAsync<TChanged>(TChanged changedEvent)
        where TChanged : ClearCacheEvent<TEntity, TId>;

    #endregion

    #region Implementation of IRepository

    public virtual async Task<List<TEntity>> GetListAsync(CancellationToken ct,
        Specification<TEntity, TId> specification = null)
    {
        var cacheKey = new CacheKey<TEntity>(nameof(GetListAsync));

        if (specification is not null)
            return await _decorated.GetListAsync(ct, specification);

        return await Cache.GetOrCreateAsync(cacheKey, CacheExpiration,
            _ => _decorated.GetListAsync(ct, specification));
    }

    public async Task<List<TDto>> GetListAsync<TDto>(CancellationToken ct,
        Specification<TEntity, TId, TDto> specification) where TDto : IDto<TId>
    {
        return await _decorated.GetListAsync(ct, specification);
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct,
        Specification<TEntity, TId> specification = null)
    {
        var cacheKey = new CacheKey<TEntity>(nameof(GetByIdAsync), id.Value.ToString());

        if (specification is not null)
            return await _decorated.GetByIdAsync(id, ct, specification);

        return await Cache.GetOrCreateAsync(cacheKey, CacheExpiration,
            _ => _decorated.GetByIdAsync(id, ct, specification));
    }

    public async Task<TDto?> GetByIdAsync<TDto>(TId id, CancellationToken ct,
        Specification<TEntity, TId, TDto> specification) where TDto : IDto<TId>
    {
        return await _decorated.GetByIdAsync(id, ct, specification);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, UserId userId, CancellationToken ct)
    {
        entity.AddDomainEventAsync(new ClearCacheEvent<TEntity, TId>(entity));

        var addedEntity = await _decorated.AddAsync(entity, userId, ct);
        var cacheKey = new CacheKey<TEntity>(nameof(GetByIdAsync), addedEntity.Id.Value.ToString());

        return await Cache.GetOrCreateAsync(cacheKey, CacheExpiration, async _ => addedEntity);
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct)
    {
        entity.AddDomainEventAsync(new ClearCacheEvent<TEntity, TId>(entity));

        var updatedEntity = await _decorated.UpdateAsync(entity, ct);
        var cacheKey = new CacheKey<TEntity>(nameof(GetByIdAsync), updatedEntity.Id.Value.ToString());

        return await Cache.GetOrCreateAsync(cacheKey, CacheExpiration, async _ => updatedEntity);
    }

    public virtual async Task<Deleted> DeleteAsync(TId id, CancellationToken ct)
    {
        var entity = await _decorated.GetByIdAsync(id, ct);

        entity.AddDomainEventAsync(new ClearCacheEvent<TEntity, TId>(entity));

        return await _decorated.DeleteAsync(id, ct);
    }

    #endregion
}