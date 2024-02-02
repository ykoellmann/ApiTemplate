using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Common.Security;

public record CurrentUser(
    UserId Id,
    string FirstName,
    string LastName,
    string Email,
    IReadOnlyList<string> Permissions,
    IReadOnlyList<string> Roles);