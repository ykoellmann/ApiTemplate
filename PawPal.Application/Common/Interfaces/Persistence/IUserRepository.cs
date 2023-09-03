using PawPal.Domain.User;
using PawPal.Domain.User.ValueObjects;
using ErrorOr;

namespace PawPal.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IRepository<User, UserId>
{
    Task<ErrorOr<User>> Add(User entity);
    Task<ErrorOr<User>?> GetByEmail(string email);
}