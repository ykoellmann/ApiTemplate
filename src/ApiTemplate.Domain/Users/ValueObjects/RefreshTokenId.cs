using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class RefreshTokenId : IdObject<RefreshTokenId>
{
    public RefreshTokenId() : base()
    {
    }
    
    public RefreshTokenId(Guid value) : base(value)
    {
    }
}