using ApiTemplate.Application.Common.EventHandlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Application.Users.Events;

public class UserCreatedEventHandler : CreatedEventHandler<IUserRepository, User, UserId, CreatedEvent<User, UserId>>
{
    private readonly IUserRepository _repository;
    
    public UserCreatedEventHandler(IUserRepository repository) : base(repository)
    {
        _repository = repository;
    }
    
    protected override async IAsyncEnumerable<string> GetCacheKeysAsync(CreatedEvent<User, UserId> notification)
    {
        yield return await _repository.EntityValueCacheKeyAsync(nameof(_repository.GetByEmailAsync),
            notification.Created.Email);
        yield return await _repository.EntityValueCacheKeyAsync(nameof(_repository.IsEmailUniqueAsync),
            notification.Created.Email);
        
        await foreach (var cacheKey in base.GetCacheKeysAsync(notification))
        {
            yield return cacheKey;
        }
    }
}