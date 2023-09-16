using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;
using Microsoft.Extensions.Caching.Memory;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.User;

public class CachedUserRepository : CachedRepository<Domain.User.User, UserId>, IUserRepository
{
    private readonly IUserRepository _decorated;
    private readonly IMemoryCache _cache;

    public CachedUserRepository(IUserRepository decorated, IMemoryCache cache) : base(decorated, cache)
    {
        _decorated = decorated;
        _cache = cache;
    }

    public override Task<Domain.User.User> Add(Domain.User.User entity, UserId userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.User.User> Add(Domain.User.User entity)
    {
        var getCacheKey = $"{typeof(Domain.User.User).Name}-get";
        var getByIdCacheKey = $"{typeof(UserId).Name}-{entity.Id}";
        
        _cache.Remove(getCacheKey);
        _cache.Remove(getByIdCacheKey);
        
        var addedEntity = await _decorated.Add(entity);
        var cacheKey = $"{typeof(UserId).Name}-{addedEntity.Id}";
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return addedEntity;
        });
    }

    public Task<ApiTemplate.Domain.User.User?> GetByEmail(string email)
    {
        var cacheKey = $"userEMail-{email}";
        
        return _cache.GetOrCreateAsync(cacheKey, entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return _decorated.GetByEmail(email);
        });
    }
}