using ApiTemplate.Domain.User;

namespace ApiTemplate.Application.Common.Interfaces.Authentication;

public interface IJwtTokenProvider
{
    string GenerateToken(Domain.User.User user);
}