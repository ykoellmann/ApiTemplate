using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;
using ApiTemplate.Infrastructure.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.User;

public class CachedUserRepository : CachedRepository<UserEntity, UserId>, IUserRepository
{
    private readonly IUserRepository _decorated;
    private readonly IDistributedCache _cache;

    public CachedUserRepository(IUserRepository decorated, IDistributedCache cache) : base(decorated, cache)
    {
        _decorated = decorated;
        _cache = cache;
    }

    [Obsolete("This method is replaced by its overload")]
    public override async Task<UserEntity> AddAsync(UserEntity entity, UserId userId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
 
    public async Task<UserEntity> AddAsync(UserEntity entity, CancellationToken cancellationToken)
    {
        await ClearCacheAsync();
        
        var addedEntity = await _decorated.AddAsync(entity, cancellationToken);
        var cacheKey = await EntityValueCacheKeyAsync(nameof(GetByIdAsync), addedEntity.Id.Value.ToString());
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeysEntityValue.Add(cacheKey);
            
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return addedEntity;
        });
    }

    public async Task<UserEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var cacheKey = await EntityValueCacheKeyAsync(nameof(GetByEmailAsync), email);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeysEntityValue.Add(cacheKey);
            
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.GetByEmailAsync(email, cancellationToken);
        });
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
    {
        var cacheKey = await EntityValueCacheKeyAsync(nameof(IsEmailUniqueAsync), email);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeysEntityValue.Add(cacheKey);
            
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.IsEmailUniqueAsync(email, cancellationToken);
        });
    }
}