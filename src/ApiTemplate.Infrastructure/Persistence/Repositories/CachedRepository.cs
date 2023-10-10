using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.User.ValueObjects;
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
    
    protected static readonly List<string> CacheKeysEntity = new();
    protected static readonly List<string> CacheKeysEntityValue = new();
    
    protected readonly IDistributedCache Cache;

    protected async Task<string> EntityCacheKey(string usage) => $"{typeof(TEntity).Name}:{usage}";

    public async Task<string> EntityValueCacheKey(string usage, string value) => $"{typeof(TEntity).Name}:{usage}:{value}";

    public CachedRepository(IRepository<TEntity, TId> decorated, IDistributedCache cache, int cacheExpirationMinutes = 10)
    {
        _decorated = decorated;
        Cache = cache;
        CacheExpiration = TimeSpan.FromMinutes(cacheExpirationMinutes) + TimeSpan.FromSeconds(new Random().Next(0, 60));
    }

    public virtual async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken)
    {
        var cacheKey = await EntityCacheKey(nameof(GetListAsync));
        return await Cache.GetOrCreateAsync(cacheKey, async entry =>
        {        
            CacheKeysEntity.Add(cacheKey);

            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.GetListAsync(cancellationToken);
        });
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken)
    {
        var cacheKey = await EntityValueCacheKey(nameof(GetByIdAsync), id.Value.ToString());
        
        return await Cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeysEntityValue.Add(cacheKey);

            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.GetByIdAsync(id, cancellationToken);
        });
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, UserId userId, CancellationToken cancellationToken)
    {
        await ClearCacheAsync();
        
        var addedEntity = await _decorated.AddAsync(entity, userId, cancellationToken);
        var cacheKey = await EntityValueCacheKey(nameof(GetByIdAsync), addedEntity.Id.Value.ToString());
        
        return await Cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeysEntityValue.Add(cacheKey);

            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return addedEntity;
        });
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await ClearCacheAsync();
        
        var updatedEntity = await _decorated.UpdateAsync(entity, cancellationToken);
        var cacheKey = await EntityValueCacheKey(nameof(GetByIdAsync), updatedEntity.Id.Value.ToString());
        
        return await Cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeysEntityValue.Add(cacheKey);

            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return updatedEntity;
        });
    }

    public virtual async Task<Deleted> DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        await ClearCacheAsync();
        
        return await _decorated.DeleteAsync(id, cancellationToken);
    }
    
    public async Task ClearCacheAsync(List<string> cacheKeys = null)
    {
        if (cacheKeys is not null)
        {
            foreach (var cacheKey in cacheKeys)
            {
                await Cache.RemoveAsync(cacheKey);
            }
            CacheKeysEntityValue.RemoveAll(k => cacheKeys.Contains(k));
        }
        
        var cacheKeysEntity = CacheKeysEntity.Where(cacheKey => cacheKey.Contains(typeof(TEntity).Name));
        foreach (var cacheKey in cacheKeysEntity)
        {
            await Cache.RemoveAsync(cacheKey);
        }
        CacheKeysEntity.RemoveAll(k => k.Contains(typeof(TEntity).Name));
    }
}