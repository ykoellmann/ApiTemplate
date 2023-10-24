using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class RefreshTokenId : IdObject<RefreshTokenId>
{
    protected RefreshTokenId(Guid value) : base(value)
    {
    }
}