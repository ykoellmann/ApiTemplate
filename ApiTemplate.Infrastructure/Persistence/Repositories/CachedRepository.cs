using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;
using Microsoft.Extensions.Caching.Memory;

namespace ApiTemplate.Infrastructure.Persistence.Repositories;

public class CachedRepository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    public readonly TimeSpan CacheExpiration;
    private readonly IRepository<TEntity, TId> _decorated;
    private readonly IMemoryCache _cache;
    private string EntityName => typeof(TEntity).Name;
    private string IdName => typeof(TId).Name;
    private string CacheKeyGet => $"{EntityName}-get";

    public CachedRepository(IRepository<TEntity, TId> decorated, IMemoryCache cache, int cacheExpirationMinutes = 5)
    {
        _decorated = decorated;
        _cache = cache;
        CacheExpiration = TimeSpan.FromMinutes(cacheExpirationMinutes);
    }

    public virtual async Task<List<TEntity>> Get()
    {
        return await _cache.GetOrCreateAsync(CacheKeyGet, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.Get();
        });
    }

    public virtual async Task<TEntity> GetById(TId id)
    {
        var cacheKey = await GetCacheKey(id);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.GetById(id);
        });
    }

    public virtual async Task<TEntity> Add(TEntity entity, UserId userId)
    {
        var getByIdCacheKey = await GetCacheKey(entity.Id);
        
        _cache.Remove(CacheKeyGet);
        _cache.Remove(getByIdCacheKey);
        
        var addedEntity = await _decorated.Add(entity, userId);
        var cacheKey = await GetCacheKey(addedEntity.Id);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return addedEntity;
        });
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        var getByIdCacheKey = await GetCacheKey(entity.Id);
        
        _cache.Remove(CacheKeyGet);
        _cache.Remove(getByIdCacheKey);
        
        var updatedEntity = await _decorated.Update(entity);
        var cacheKey = await GetCacheKey(updatedEntity.Id);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return updatedEntity;
        });
    }

    public virtual async Task<Deleted> Delete(TId id)
    {
        var getByIdCacheKey = await GetCacheKey(id);
        
        _cache.Remove(CacheKeyGet);
        _cache.Remove(getByIdCacheKey);
        
        return await _decorated.Delete(id);
    }
    
    private async Task<string> GetCacheKey(TId id)
    {
        return $"{IdName}-{id.Value}";
    }
}