using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IRepository<UserEntity, UserId>
{
    Task<UserEntity> AddAsync(UserEntity entity, CancellationToken cancellationToken);
    Task<UserEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken);
}