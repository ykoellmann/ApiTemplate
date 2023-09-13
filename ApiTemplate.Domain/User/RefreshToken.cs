using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.User.ValueObjects;

namespace ApiTemplate.Domain.User;

public class RefreshToken : Entity<RefreshTokenId>
{
    private RefreshToken(RefreshTokenId id, string token, DateTime expires, UserId userId) : base(id)
    {
        Token = token;
        Expires = expires;
        UserId = userId;
    }
    
    public string Token { get; set; } = null!;
    public DateTime Expires { get; set; }
    // public bool IsExpired => DateTime.UtcNow >= Expires;
    public UserId UserId { get; set; } = null!;
    public virtual User User { get; set; } = null!;

    public static RefreshToken Create(string token, DateTime expires, UserId userId)
    {
        return new RefreshToken(RefreshTokenId.CreateUnique(), token, expires, userId);
    }
}