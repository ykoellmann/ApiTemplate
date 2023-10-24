using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class UserId : IdObject<UserId>
{
    private UserId(Guid value) : base(value)
    {
    }
    
    //Used for Json serialization
    private UserId() : base()
    {
    }
}