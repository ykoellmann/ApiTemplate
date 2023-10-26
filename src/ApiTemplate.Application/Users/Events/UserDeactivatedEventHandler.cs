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
    
    
}