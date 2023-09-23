using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.User.ValueObjects;
using ApiTemplate.Infrastructure.Extensions;
using ErrorOr;
using Microsoft.Extensions.Caching.Distributed;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.User;

public class CachedUserRepository : CachedRepository<Domain.User.User, UserId>, IUserRepository
{
    private readonly IUserRepository _decorated;
    private readonly IDistributedCache _cache;

    public CachedUserRepository(IUserRepository decorated, IDistributedCache cache) : base(decorated, cache)
    {
        _decorated = decorated;
        _cache = cache;
    }

    public override Task<Domain.User.User> AddAsync(Domain.User.User entity, UserId userId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
 
    public async Task<Domain.User.User> AddAsync(Domain.User.User entity)
    {
        var getCacheKey = $"{EntityName}-get";
        var getByIdCacheKey = $"{IdName}-{entity.Id}";
        var emailCacheKey = $"userEMail-{entity.Email}";
        var emailIsUniqueCacheKey = $"userEMailUnique-{entity.Email}";
        
        _cache.Remove(getCacheKey);
        _cache.Remove(getByIdCacheKey);
        _cache.Remove(emailCacheKey);
        _cache.Remove(emailIsUniqueCacheKey);
        
        var addedEntity = await _decorated.AddAsync(entity);
        var cacheKey = $"{IdName}-{addedEntity.Id}";
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return addedEntity;
        });
    }

    public override Task<Domain.User.User> UpdateAsync(Domain.User.User entity, CancellationToken cancellationToken)
    {
        var emailCacheKey = $"userEMail-{entity.Email}";
        _cache.Remove(emailCacheKey);
        
        return base.UpdateAsync(entity, cancellationToken);
    }

    public async Task<ApiTemplate.Domain.User.User?> GetByEmailAsync(string email)
    {
        var cacheKey = $"userEMail-{email}";
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.GetByEmailAsync(email);
        });
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        var cacheKey = $"userEMailUnique-{email}";
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.IsEmailUniqueAsync(email);
        });
    }
}