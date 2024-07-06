using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class RefreshTokenId : Id<RefreshTokenId>
{
    public RefreshTokenId()
    {
    }

    public RefreshTokenId(Guid value) : base(value)
    {
    }
}