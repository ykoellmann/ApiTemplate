using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class UserPermissionId : Id<UserPermissionId>
{
    public UserPermissionId()
    {
    }

    public UserPermissionId(Guid value) : base(value)
    {
    }
}