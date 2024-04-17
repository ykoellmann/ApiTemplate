using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public record UserNameDto(UserId Id, string FirstName, string LastName) : IDto<UserId>;