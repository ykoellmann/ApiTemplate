using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public class UserPermission : Entity<UserPermissionId>
{

    public UserPermission(UserId userId, PermissionId permissionId) : base(new UserPermissionId())
    {
        UserId = userId;
        PermissionId = permissionId;
    }

    public UserId UserId { get; private set; }
    public PermissionId PermissionId { get; private set; }
    
    public User User { get; private set; } = null!;
    public Permission Permission { get; private set; } = null!;
    
    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override UserId CreatedBy { get; set; } = null!;

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override UserId UpdatedBy { get; set; } = null!;
    

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override User CreatedByUser { get; set; } = null!;

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override User UpdatedByUser { get; set; } = null!;
    
}