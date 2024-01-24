using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class UserId : Id<UserId>
{
    public UserId()
    {
    }
    
    public UserId(Guid value) : base(value)
    {
    }
}