using ErrorOr;
using Microsoft.Extensions.Caching.Memory;
using PawPal.Application.Common.Interfaces.Persistence;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Repositories.User;

public class CachedUserRepository : IUserRepository
{
    private readonly IUserRepository _decorated;
    private readonly IMemoryCache _cache;

    public CachedUserRepository(IUserRepository decorated, IMemoryCache cache)
    {
        _decorated = decorated;
        _cache = cache;
    }

    public Task<ErrorOr<List<Domain.User.User>>> Get() => _decorated.Get();
    public Task<ErrorOr<Domain.User.User>> GetById(UserId id)
    {
        var cacheKey = $"userId-{id}";
        
        return _cache.GetOrCreateAsync(cacheKey, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
            
            return _decorated.GetById(id);
        });
    }

    public Task<ErrorOr<Domain.User.User>> Add(Domain.User.User entity, UserId userId) => _decorated.Add(entity, userId);
    public Task<ErrorOr<Domain.User.User>> Update(Domain.User.User entity) => _decorated.Update(entity);
    public Task<ErrorOr<Deleted>> Delete(UserId id) => _decorated.Delete(id);
    public Task<ErrorOr<Domain.User.User>> Add(Domain.User.User entity) => _decorated.Add(entity);
    public Task<ErrorOr<Domain.User.User>?> GetByEmail(string email)
    {
        var cacheKey = $"userEMail-{email}";
        
        return _cache.GetOrCreateAsync(cacheKey, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
            
            return _decorated.GetByEmail(email);
        });
    }
}