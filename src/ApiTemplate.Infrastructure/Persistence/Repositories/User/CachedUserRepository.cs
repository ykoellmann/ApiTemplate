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
 
    public async Task<Domain.User.User> AddAsync(Domain.User.User entity, CancellationToken cancellationToken = default)
    {
        await ClearCacheAsync();
        
        var addedEntity = await _decorated.AddAsync(entity, cancellationToken);
        var cacheKey = await EntityValueCacheKey(nameof(GetByIdAsync), addedEntity.Id.Value.ToString());
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeysEntityValue.Add(cacheKey);
            
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return addedEntity;
        });
    }

    public async Task<ApiTemplate.Domain.User.User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var cacheKey = await EntityValueCacheKey(nameof(GetByEmailAsync), email);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeysEntityValue.Add(cacheKey);
            
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.GetByEmailAsync(email);
        });
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default)
    {
        var cacheKey = await EntityValueCacheKey(nameof(IsEmailUniqueAsync), email);
        
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            CacheKeysEntityValue.Add(cacheKey);
            
            entry.SetAbsoluteExpiration(CacheExpiration);
            
            return await _decorated.IsEmailUniqueAsync(email);
        });
    }
}