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

    public CachedRepository(IRepository<TEntity, TId> decorated, IMemoryCache cache, int cacheExpirationMinutes = 2)
    {
        _decorated = decorated;
        _cache = cache;
        _cacheExpiration = TimeSpan.FromMinutes(cacheExpirationMinutes);
    }

    public async Task<List<TEntity>> Get()
    {
        var cacheKey = $"{typeof(TEntity).Name}-get";
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(_cacheExpiration);
            
            return await _decorated.Get();
        });
    }

    public async Task<TEntity> GetById(TId id)
    {
        var cacheKey = $"{typeof(TId).Name}-{id.Value}";
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(_cacheExpiration);
            
            return await _decorated.GetById(id);
        });
    }

    public async Task<TEntity> Add(TEntity entity, UserId userId)
    {
        var getCacheKey = $"{typeof(TEntity).Name}-get";
        var getByIdCacheKey = $"{typeof(TId).Name}-{entity.Id.Value}";
        
        _cache.Remove(getCacheKey);
        _cache.Remove(getByIdCacheKey);
        
        var addedEntity = await _decorated.Add(entity, userId);
        var cacheKey = $"{typeof(TId).Name}-{addedEntity.Id.Value}";
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(_cacheExpiration);
            
            return addedEntity;
        });
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        var getCacheKey = $"{typeof(TEntity).Name}-get";
        var getByIdCacheKey = $"{typeof(TId).Name}-{entity.Id.Value}";
        
        _cache.Remove(getCacheKey);
        _cache.Remove(getByIdCacheKey);
        
        var updatedEntity = await _decorated.Update(entity);
        var cacheKey = $"{typeof(TId).Name}-{updatedEntity.Id.Value}";
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(_cacheExpiration);
            
            return updatedEntity;
        });
    }

    public Task<Deleted> Delete(TId id)
    {
        var getCacheKey = $"{typeof(TEntity).Name}-get";
        var getByIdCacheKey = $"{typeof(TId).Name}-{id.Value}";
        
        _cache.Remove(getCacheKey);
        _cache.Remove(getByIdCacheKey);
        
        return _decorated.Delete(id);
    }
}