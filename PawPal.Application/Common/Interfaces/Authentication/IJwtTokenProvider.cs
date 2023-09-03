using PawPal.Domain.User;

namespace PawPal.Application.Common.Interfaces.Authentication;

public interface IJwtTokenProvider
{
    string GenerateToken(User user);
}