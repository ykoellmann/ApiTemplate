namespace ApiTemplate.Application.Common.Interfaces.Security;

public interface IPasswordHashProvider
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string passwordHash);
}