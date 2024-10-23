using System.Security.Cryptography;
using ApiTemplate.Application.Common.Interfaces.Security;

namespace ApiTemplate.Infrastructure.Security;

public class PasswordHashProvider : IPasswordHashProvider
{
    private const int SaltSize = 16; // 128 bit
    private const int KeySize = 32; // 256 bit
    private const int Iterations = 10000;

    public string HashPassword(string password)
    {
        // Generate a salt using RandomNumberGenerator
        var salt = new byte[SaltSize];
        RandomNumberGenerator.Fill(salt);

        // Create the Rfc2898DeriveBytes and get the hash value
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(KeySize);

        // Combine the salt and hash into a single string
        var hashBytes = new byte[SaltSize + KeySize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

        // Convert to base64
        var base64Hash = Convert.ToBase64String(hashBytes);

        // Return the result
        return base64Hash;
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        // Get the bytes of the hashed password
        var hashBytes = Convert.FromBase64String(hashedPassword);

        // Extract the salt
        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        // Compute the hash on the password the user entered
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(KeySize);

        // Compare the results
        for (int i = 0; i < KeySize; i++)
        {
            if (hashBytes[i + SaltSize] != hash[i])
            {
                return false;
            }
        }

        return true;
    }
}