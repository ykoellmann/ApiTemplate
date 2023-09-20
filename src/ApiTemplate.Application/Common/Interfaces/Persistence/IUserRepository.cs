using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IRepository<User, UserId>
{
    Task<User> AddAsync(User entity);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> IsEmailUniqueAsync(string email);
}