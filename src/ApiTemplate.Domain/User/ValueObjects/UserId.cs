using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.User.ValueObjects;

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