using ApiTemplate.Application.Common.EventHandlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Application.Users.Events;

public class UserUpdatedEventHandler : UpdatedEventHandler<IUserRepository, User, UserId, UpdatedEvent<User, UserId>>
{
    private readonly IUserRepository _userRepository;

    public UserUpdatedEventHandler(IUserRepository userRepository) : base(userRepository)
    {
        _userRepository = userRepository;
    }

    protected override async IAsyncEnumerable<string> GetCacheKeysAsync(UpdatedEvent<User, UserId> notification)
    {
        yield return await _userRepository.EntityValueCacheKeyAsync(nameof(_userRepository.GetByEmailAsync),
            notification.Updated.Email);
        await foreach (var cacheKey in base.GetCacheKeysAsync(notification))
        {
            yield return cacheKey;
        }
    }
}