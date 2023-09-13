using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.User.ValueObjects;

public class RefreshTokenId : IdObject<RefreshTokenId>
{
    protected RefreshTokenId(Guid value) : base(value)
    {
    }
}