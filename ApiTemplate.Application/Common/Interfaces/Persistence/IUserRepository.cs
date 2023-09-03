using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IRepository<User, UserId>
{
    Task<ErrorOr<User>> Add(User entity);
    Task<ErrorOr<User>?> GetByEmail(string email);
}