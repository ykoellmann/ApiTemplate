using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public class UserRole : Entity<UserRoleId>
{
    public UserId UserId { get; set; } = null!;
    public RoleId RoleId { get; set; } = null!;
    
    public virtual User User { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
    
    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override UserId CreatedBy { get; set; } = null!;

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override UserId UpdatedBy { get; set; } = null!;
    

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override User CreatedByUser { get; set; } = null!;

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override User UpdatedByUser { get; set; } = null!;
    
    public UserRole(UserId userId, RoleId roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}