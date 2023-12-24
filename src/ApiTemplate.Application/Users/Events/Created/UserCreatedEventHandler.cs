using ApiTemplate.Application.Common.Events.Created;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Application.Users.Events.Created;

public class UserCreatedEventHandler 
    : CreatedEventHandler<IUserRepository, User, UserId, IUserDto, CreatedEvent<User, UserId>>
{
    private readonly IUserRepository _repository;

    public UserCreatedEventHandler(IUserRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async IAsyncEnumerable<string> GetCacheKeysAsync(CreatedEvent<User, UserId> createdEvent)
    {
        yield return await _repository.EntityValueCacheKeyAsync(nameof(_repository.GetByEmailAsync),
            createdEvent.Created.Email);
        yield return await _repository.EntityValueCacheKeyAsync(nameof(_repository.IsEmailUniqueAsync),
            createdEvent.Created.Email);
    }
}