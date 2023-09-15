using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;
using Microsoft.Extensions.Caching.Memory;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.User;

public class CachedUserRepository : IUserRepository
{
    private readonly IUserRepository _decorated;
    private readonly IMemoryCache _cache;

    public CachedUserRepository(IUserRepository decorated, IMemoryCache cache)
    {
        _decorated = decorated;
        _cache = cache;
    }

    public Task<List<ApiTemplate.Domain.User.User>> Get() => _decorated.Get();
    public Task<ApiTemplate.Domain.User.User> GetById(UserId id)
    {
        var cacheKey = $"userId-{id}";
        
        return _cache.GetOrCreateAsync(cacheKey, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
            
            return _decorated.GetById(id);
        });
    }

    public Task<ApiTemplate.Domain.User.User> Add(ApiTemplate.Domain.User.User entity, UserId userId) => _decorated.Add(entity, userId);
    public Task<ApiTemplate.Domain.User.User> Update(ApiTemplate.Domain.User.User entity) => _decorated.Update(entity);
    public Task<Deleted> Delete(UserId id) => _decorated.Delete(id);
    public Task<ApiTemplate.Domain.User.User> Add(ApiTemplate.Domain.User.User entity) => _decorated.Add(entity);
    public Task<ApiTemplate.Domain.User.User?> GetByEmail(string email)
    {
        var cacheKey = $"userEMail-{email}";
        
        return _cache.GetOrCreateAsync(cacheKey, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
            
            return _decorated.GetByEmail(email);
        });
    }
}