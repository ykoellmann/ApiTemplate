using ApiTemplate.Application.Common.Events;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Application.Users.Events;

public record UserCreatedEvent(User user) : ClearCacheEvent<User, UserId>(user);