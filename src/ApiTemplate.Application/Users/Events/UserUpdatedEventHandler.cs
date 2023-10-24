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

    public override async Task<List<string>> GetCacheKeysAsync(UpdatedEvent<User, UserId> notification)
    {
        return new List<string>
        {
            await _userRepository.EntityValueCacheKeyAsync(nameof(_userRepository.GetByEmailAsync), notification.Updated.Email)
        };
    }
}