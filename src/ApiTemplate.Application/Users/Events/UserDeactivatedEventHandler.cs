using ApiTemplate.Application.Common.EventHandlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Application.Users.Events;

public class UserDeactivatedEventHandler : DeletedEventHandler<IUserRepository, User, UserId, DeletedEvent<User, UserId>>
{
    private readonly IUserRepository _repository;
    
    public UserDeactivatedEventHandler(IUserRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async IAsyncEnumerable<string> GetCacheKeysAsync(DeletedEvent<User, UserId> notification)
    {
        yield return await _repository.EntityValueCacheKeyAsync(nameof(_repository.GetByEmailAsync),
            notification.Deleted.Email);
        yield return await _repository.EntityValueCacheKeyAsync(nameof(_repository.IsEmailUniqueAsync),
            notification.Deleted.Email);
        
        await foreach (var cacheKey in base.GetCacheKeysAsync(notification))
        {
            yield return cacheKey;
        }
    }
}