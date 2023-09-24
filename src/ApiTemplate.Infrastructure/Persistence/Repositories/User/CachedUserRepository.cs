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

    [Obsolete("This method is replaced by its overload")]
    public override Task<Domain.User.User> AddAsync(Domain.User.User entity, UserId userId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
 
    public async Task<Domain.User.User> AddAsync(Domain.User.User entity)
    {
        await ClearCacheAsync(entity);
        
        var addedEntity = await _decorated.AddAsync(entity);
        var cacheKey = $"{CacheKeyPrefix}-{addedEntity.Id}";
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeys.Add(cacheKey);
            
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return addedEntity;
        });
    }

    public override async Task<Domain.User.User> UpdateAsync(Domain.User.User entity, CancellationToken cancellationToken)
    {
        await ClearCacheAsync(entity);
        
        return await base.UpdateAsync(entity, cancellationToken);
    }

    public async Task<ApiTemplate.Domain.User.User?> GetByEmailAsync(string email)
    {
        var cacheKey = $"{CacheKeyPrefix}-{email}";
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeys.Add(cacheKey);
            
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.GetByEmailAsync(email);
        });
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        var cacheKey = $"{CacheKeyPrefix}-isUnique-{email}";
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeys.Add(cacheKey);
            
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.IsEmailUniqueAsync(email);
        });
    }

    protected override async Task ClearCacheAsync(Domain.User.User user)
    {
        var emailCacheKey = $"{CacheKeyPrefix}-{user.Email}";
        var isUniqueCacheKey = $"{CacheKeyPrefix}-isUnique-{user.Email}";
        
        await _cache.RemoveAsync(emailCacheKey);
        await _cache.RemoveAsync(isUniqueCacheKey);
        
        await base.ClearCacheAsync(user);
    }
}