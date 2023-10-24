using ApiTemplate.Domain.Users;

namespace ApiTemplate.Application.Common.Interfaces.Authentication;

public interface IJwtTokenProvider
{
    string GenerateToken(User user);
}