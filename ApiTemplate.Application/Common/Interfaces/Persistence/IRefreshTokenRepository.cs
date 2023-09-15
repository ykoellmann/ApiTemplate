using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IRefreshTokenRepository : IRepository<RefreshToken, RefreshTokenId>
{
    
}