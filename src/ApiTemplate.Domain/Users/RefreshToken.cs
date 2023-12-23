using System.Security.Cryptography;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public class RefreshToken : Entity<RefreshTokenId>
{
    public RefreshToken(UserId userId) : base(new RefreshTokenId())
    {
        Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        Expires = DateTime.UtcNow.AddMinutes(1);
        UserId = userId;
    }
    
    public string Token { get; set; } = null!;
    public DateTime Expires { get; set; }
    public bool Disabled { get; set; }
    public bool Expired => Disabled || Expires < DateTime.UtcNow;
    public UserId UserId { get; set; } = null!;
    public User User { get; set; } = null!;
}