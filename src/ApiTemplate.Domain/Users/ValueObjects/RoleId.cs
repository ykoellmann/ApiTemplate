using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class RoleId : Id<RoleId>
{
    public RoleId()
    {
    }
    
    public RoleId(Guid value) : base(value)
    {
    }
}