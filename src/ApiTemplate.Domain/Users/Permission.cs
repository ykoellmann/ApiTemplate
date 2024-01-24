using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public class Permission : Entity<PermissionId>
{    
    public string Name { get; private set; } = default!;

    public Permission(PermissionId id, string name) : base(id)
    {
        Name = name;
    }
}