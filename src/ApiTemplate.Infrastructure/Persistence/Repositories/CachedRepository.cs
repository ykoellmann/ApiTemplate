using ApiTemplate.Application.Common.Events;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;
using ApiTemplate.Infrastructure.Extensions;
using ErrorOr;
using Microsoft.Extensions.Caching.Distributed;

namespace ApiTemplate.Infrastructure.Persistence.Repositories;

public abstract class CachedRepository<TEntity, TId, TIDto> : IRepository<TEntity, TId, TIDto>
    where TEntity : Entity<TId>
    where TId : Id<TId>
    where TIDto : IDto<TId>
{
    public readonly TimeSpan CacheExpiration;
    private readonly IRepository<TEntity, TId, TIDto> _decorated;

    protected readonly IDistributedCache Cache;

    public CachedRepository(IRepository<TEntity, TId, TIDto> decorated, IDistributedCache cache,
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
    
    public virtual async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken,
        Specification<TEntity, TId> specification = null)
    {
        var cacheKey = new CacheKey<TEntity>(nameof(GetListAsync));
        
        if (specification is not null)
            return await _decorated.GetListAsync(cancellationToken, specification);
        
        return await Cache.GetOrCreateAsync(cacheKey, CacheExpiration,
            _ => _decorated.GetListAsync(cancellationToken, specification));
    }

    public Task<List<TDto>> GetDtoListAsync<TDto>(CancellationToken cancellationToken) where TDto : Dto<TDto, TEntity, TId>, TIDto, new()
    {
        var cacheKey = new CacheKey<TEntity>(nameof(GetDtoListAsync), typeof(TDto).Name);
        
        return Cache.GetOrCreateAsync(cacheKey, CacheExpiration,
            _ => _decorated.GetDtoListAsync<TDto>(cancellationToken));
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken,
        Specification<TEntity, TId> specification = null)
    {
        var cacheKey = new CacheKey<TEntity>(nameof(GetByIdAsync), id.Value.ToString());
        
        if (specification is not null)
            return await _decorated.GetByIdAsync(id, cancellationToken, specification);

        return await Cache.GetOrCreateAsync(cacheKey, CacheExpiration,
            _ => _decorated.GetByIdAsync(id, cancellationToken, specification));
    }

    public async Task<TDto?> GetDtoByIdAsync<TDto>(TId id, CancellationToken cancellationToken)
        where TDto : Dto<TDto, TEntity, TId>, TIDto, new()
    {
        var cacheKey =
            new CacheKey<TEntity>(nameof(GetDtoByIdAsync), typeof(TDto).Name, id.Value.ToString());

        return await Cache.GetOrCreateAsync(cacheKey, CacheExpiration,
            _ => _decorated.GetDtoByIdAsync<TDto>(id, cancellationToken));
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, UserId userId, CancellationToken cancellationToken)
    {
        entity.AddDomainEventAsync(new ClearCacheEvent<TEntity, TId>(entity));

        var addedEntity = await _decorated.AddAsync(entity, userId, cancellationToken);
        var cacheKey = new CacheKey<TEntity>(nameof(GetByIdAsync), addedEntity.Id.Value.ToString());

        return await Cache.GetOrCreateAsync(cacheKey, CacheExpiration, async _ => addedEntity);
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        entity.AddDomainEventAsync(new ClearCacheEvent<TEntity, TId>(entity));

        var updatedEntity = await _decorated.UpdateAsync(entity, cancellationToken);
        var cacheKey = new CacheKey<TEntity>(nameof(GetByIdAsync), updatedEntity.Id.Value.ToString());

        return await Cache.GetOrCreateAsync(cacheKey, CacheExpiration, async _ => updatedEntity);
    }

    public virtual async Task<Deleted> DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        var entity = await _decorated.GetByIdAsync(id, cancellationToken);

        entity.AddDomainEventAsync(new ClearCacheEvent<TEntity, TId>(entity));

        return await _decorated.DeleteAsync(id, cancellationToken);
    }

    #endregion
}