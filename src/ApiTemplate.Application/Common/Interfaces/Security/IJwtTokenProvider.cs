using ApiTemplate.Domain.Users;

namespace ApiTemplate.Application.Common.Interfaces.Security;

public interface IJwtTokenProvider
{
    string GenerateToken(User user);
}