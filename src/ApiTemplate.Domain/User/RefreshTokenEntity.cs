using System.Security.Cryptography;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.User.ValueObjects;

namespace ApiTemplate.Domain.User;

public class RefreshTokenEntity : Entity<RefreshTokenId>
{
    private RefreshTokenEntity(RefreshTokenId id, string token, DateTime expires, UserId userId) : base(id)
    {
        Token = token;
        Expires = expires;
        UserId = userId;
    }
    
    //Used for Json serialization
    private RefreshTokenEntity() : base()
    {
    }
    
    public string Token { get; set; } = null!;
    public DateTime Expires { get; set; }
    public bool Disabled { get; set; } = false;
    public bool Expired => Disabled || Expires < DateTime.UtcNow;
    public UserId UserId { get; set; } = null!;
    public virtual UserEntity UserEntity { get; set; } = null!;

    public static RefreshTokenEntity Create(UserId userId)
    {
        return new RefreshTokenEntity(
            RefreshTokenId.CreateUnique(), 
            Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)), 
            DateTime.UtcNow.AddMinutes(1), 
            userId);
    }
}