using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IRepository<User, UserId>
{
    Task<User> Add(User entity);
    Task<User?> GetByEmail(string email);
}