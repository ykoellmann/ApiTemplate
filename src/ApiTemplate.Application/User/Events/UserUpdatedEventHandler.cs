using ApiTemplate.Application.Common.EventHandlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.User.ValueObjects;
using MediatR;

namespace ApiTemplate.Application.User.Events;

public class UserUpdatedEventHandler : UpdatedEventHandler<IUserRepository, Domain.User.User, UserId, UpdatedEvent<Domain.User.User, UserId>>
{
    private readonly IUserRepository _userRepository;

    public UserUpdatedEventHandler(IUserRepository userRepository) : base(userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<List<string>> GetCacheKeys(UpdatedEvent<Domain.User.User, UserId> notification)
    {
        return new List<string>
        {
            await _userRepository.EntityValueCacheKeyAsync(nameof(_userRepository.GetByEmailAsync), notification.Updated.Email)
        };
    }
}