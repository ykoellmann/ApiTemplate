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
    protected static readonly List<string> CacheKeys = new();
    protected readonly IDistributedCache Cache;
    protected string CacheKeyPrefix => $"{typeof(TEntity).Name}";
    protected string CacheKeyGet => $"{CacheKeyPrefix}-get";

    public CachedRepository(IRepository<TEntity, TId> decorated, IDistributedCache cache, int cacheExpirationMinutes = 5)
    {
        _decorated = decorated;
        Cache = cache;
        CacheExpiration = TimeSpan.FromMinutes(cacheExpirationMinutes);
    }

    public virtual async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken)
    {
        return await Cache.GetOrCreateAsync(CacheKeyGet, async entry =>
        {        
            CacheKeys.Add(CacheKeyGet);

            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.GetListAsync(cancellationToken);
        });
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken)
    {
        var cacheKey = await GetCacheKey(id);
        
        return await Cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeys.Add(cacheKey);

            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.GetByIdAsync(id, cancellationToken);
        });
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, UserId userId, CancellationToken cancellationToken)
    {
        await ClearCacheAsync(entity);
        
        var addedEntity = await _decorated.AddAsync(entity, userId, cancellationToken);
        var cacheKey = await GetCacheKey(addedEntity.Id);
        
        return await Cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeys.Add(cacheKey);

            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return addedEntity;
        });
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await ClearCacheAsync(entity);
        
        var updatedEntity = await _decorated.UpdateAsync(entity, cancellationToken);
        var cacheKey = await GetCacheKey(updatedEntity.Id);
        
        return await Cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeys.Add(cacheKey);

            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return updatedEntity;
        });
    }

    public virtual async Task<Deleted> DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        await ClearCacheAsync(id.Value);
        
        return await _decorated.DeleteAsync(id, cancellationToken);
    }
    
    protected async Task<string> GetCacheKey(TId id)
    {
        return $"{CacheKeyPrefix}-{id.Value}";
    }
    
    protected virtual async Task ClearCacheAsync(TEntity entity)
    {
        foreach (var cacheKey in CacheKeys.Where(ck => ck.Contains(entity.Id.Value.ToString())))
        {
            Cache.Remove(cacheKey);
            CacheKeys.Remove(cacheKey);
        }

        CacheKeys.Remove(CacheKeyGet);
    }
    
    protected virtual async Task ClearCacheAsync(dynamic cacheKeyPart)
    {
        foreach (var cacheKey in CacheKeys.Where(ck => ck.Contains(cacheKeyPart.ToString())))
        {
            Cache.Remove(cacheKey);
            CacheKeys.Remove(cacheKey);
        }

        CacheKeys.Remove(CacheKeyGet);
    }
}