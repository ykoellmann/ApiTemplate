using ApiTemplate.Application.Common.EventHandlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Application.Users.Events;

public class UserDeactivatedEventHandler : DeletedEventHandler<IUserRepository, User, UserId, DeletedEvent<User, UserId>>
{
    public UserDeactivatedEventHandler(IUserRepository repository) : base(repository)
    {
    }

    protected override async IAsyncEnumerable<string> GetCacheKeysAsync(DeletedEvent<User, UserId> notification)
    {
        await foreach (var cacheKey in base.GetCacheKeysAsync(notification))
        {
            yield return cacheKey;
        }
    }
}