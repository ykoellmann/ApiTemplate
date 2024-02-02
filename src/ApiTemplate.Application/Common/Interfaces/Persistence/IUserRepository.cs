using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IRepository<User, UserId>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken ct);
    Task<bool> IsEmailUniqueAsync(string email, CancellationToken ct);
    Task<User> AddAsync(User entity, CancellationToken ct);
}