using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class UserId : IdObject<UserId>
{
    public UserId() : base()
    {
    }
    
    public UserId(Guid value) : base(value)
    {
    }
}