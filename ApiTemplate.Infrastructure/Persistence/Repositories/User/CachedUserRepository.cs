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

    public Task<ErrorOr<List<ApiTemplate.Domain.User.User>>> Get() => _decorated.Get();
    public Task<ErrorOr<ApiTemplate.Domain.User.User>> GetById(UserId id)
    {
        var cacheKey = $"userId-{id}";
        
        return _cache.GetOrCreateAsync(cacheKey, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
            
            return _decorated.GetById(id);
        });
    }

    public Task<ErrorOr<ApiTemplate.Domain.User.User>> Add(ApiTemplate.Domain.User.User entity, UserId userId) => _decorated.Add(entity, userId);
    public Task<ErrorOr<ApiTemplate.Domain.User.User>> Update(ApiTemplate.Domain.User.User entity) => _decorated.Update(entity);
    public Task<ErrorOr<Deleted>> Delete(UserId id) => _decorated.Delete(id);
    public Task<ErrorOr<ApiTemplate.Domain.User.User>> Add(ApiTemplate.Domain.User.User entity) => _decorated.Add(entity);
    public Task<ErrorOr<ApiTemplate.Domain.User.User>?> GetByEmail(string email)
    {
        var cacheKey = $"userEMail-{email}";
        
        return _cache.GetOrCreateAsync(cacheKey, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
            
            return _decorated.GetByEmail(email);
        });
    }
}