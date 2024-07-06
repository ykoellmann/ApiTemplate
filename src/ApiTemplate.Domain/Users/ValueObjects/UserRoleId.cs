using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class UserRoleId : Id<UserRoleId>
{
    public UserRoleId()
    {
    }

    public UserRoleId(Guid value) : base(value)
    {
    }
}