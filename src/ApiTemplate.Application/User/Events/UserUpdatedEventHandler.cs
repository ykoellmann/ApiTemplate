using ApiTemplate.Application.Common.EventHandlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;

namespace ApiTemplate.Application.User.Events;

public class UserUpdatedEventHandler : UpdatedEventHandler<IUserRepository, UserEntity, UserId, UpdatedEvent<UserEntity, UserId>>
{
    private readonly IUserRepository _userRepository;

    public UserUpdatedEventHandler(IUserRepository userRepository) : base(userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<List<string>> GetCacheKeysAsync(UpdatedEvent<UserEntity, UserId> notification)
    {
        return new List<string>
        {
            await _userRepository.EntityValueCacheKeyAsync(nameof(_userRepository.GetByEmailAsync), notification.Updated.Email)
        };
    }
}