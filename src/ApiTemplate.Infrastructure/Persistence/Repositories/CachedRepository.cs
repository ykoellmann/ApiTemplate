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
    private readonly IDistributedCache _cache;
    public string EntityName => typeof(TEntity).Name;
    public string IdName => typeof(TId).Name;
    public string CacheKeyGet => $"{EntityName}-get";

    public CachedRepository(IRepository<TEntity, TId> decorated, IDistributedCache cache, int cacheExpirationMinutes = 5)
    {
        _decorated = decorated;
        _cache = cache;
        CacheExpiration = TimeSpan.FromMinutes(cacheExpirationMinutes);
    }

    public virtual async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken)
    {
        return await _cache.GetOrCreateAsync(CacheKeyGet, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.GetListAsync(cancellationToken);
        });
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken)
    {
        var cacheKey = await GetCacheKey(id);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.GetByIdAsync(id, cancellationToken);
        });
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, UserId userId, CancellationToken cancellationToken)
    {
        var getByIdCacheKey = await GetCacheKey(entity.Id);
        
        _cache.Remove(CacheKeyGet);
        _cache.Remove(getByIdCacheKey);
        
        var addedEntity = await _decorated.AddAsync(entity, userId, cancellationToken);
        var cacheKey = await GetCacheKey(addedEntity.Id);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return addedEntity;
        });
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var getByIdCacheKey = await GetCacheKey(entity.Id);
        
        _cache.Remove(CacheKeyGet);
        _cache.Remove(getByIdCacheKey);
        
        var updatedEntity = await _decorated.UpdateAsync(entity, cancellationToken);
        var cacheKey = await GetCacheKey(updatedEntity.Id);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return updatedEntity;
        });
    }

    public virtual async Task<Deleted> DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        var getByIdCacheKey = await GetCacheKey(id);
        
        _cache.Remove(CacheKeyGet);
        _cache.Remove(getByIdCacheKey);
        
        return await _decorated.DeleteAsync(id, cancellationToken);
    }
    
    private async Task<string> GetCacheKey(TId id)
    {
        return $"{IdName}-{id.Value}";
    }

    protected void tmp()
    {
        
    }
}