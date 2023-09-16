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
    private readonly IRepository<TEntity, TId> _decorated;
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _cacheExpiration;
    private string EntityName => typeof(TEntity).Name;
    private string IdName => typeof(TId).Name;
    private string CacheKeyGet => $"{EntityName}-get";

    public CachedRepository(IRepository<TEntity, TId> decorated, IMemoryCache cache, int cacheExpirationMinutes = 2)
    {
        _decorated = decorated;
        _cache = cache;
        _cacheExpiration = TimeSpan.FromMinutes(cacheExpirationMinutes);
    }

    public async Task<List<TEntity>> Get()
    {
        return await _cache.GetOrCreateAsync(CacheKeyGet, async entry =>
        {
            entry.SetAbsoluteExpiration(_cacheExpiration);
            
            return await _decorated.Get();
        });
    }

    public async Task<TEntity> GetById(TId id)
    {
        var cacheKey = await GetCacheKey(id);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(_cacheExpiration);
            
            return await _decorated.GetById(id);
        });
    }

    public async Task<TEntity> Add(TEntity entity, UserId userId)
    {
        var getByIdCacheKey = await GetCacheKey(entity.Id);
        
        _cache.Remove(CacheKeyGet);
        _cache.Remove(getByIdCacheKey);
        
        var addedEntity = await _decorated.Add(entity, userId);
        var cacheKey = await GetCacheKey(addedEntity.Id);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(_cacheExpiration);
            
            return addedEntity;
        });
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        var getByIdCacheKey = await GetCacheKey(entity.Id);
        
        _cache.Remove(CacheKeyGet);
        _cache.Remove(getByIdCacheKey);
        
        var updatedEntity = await _decorated.Update(entity);
        var cacheKey = await GetCacheKey(updatedEntity.Id);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(_cacheExpiration);
            
            return updatedEntity;
        });
    }

    public async Task<Deleted> Delete(TId id)
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