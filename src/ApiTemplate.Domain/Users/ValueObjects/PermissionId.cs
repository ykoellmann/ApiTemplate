using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class PermissionId : Id<PermissionId>
{
    public PermissionId()
    {
    }

    public PermissionId(Guid value) : base(value)
    {
    }
}