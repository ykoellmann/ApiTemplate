using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public class Role : Entity<RoleId>
{
    public Role(string name) : base(new RoleId())
    
    {
        Name = name;
    }

    public string Name { get; set; }
    
    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override UserId CreatedBy { get; set; } = null!;

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override UserId UpdatedBy { get; set; } = null!;
    

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override User CreatedByUser { get; set; } = null!;

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override User UpdatedByUser { get; set; } = null!;

    public virtual IEnumerable<UserRole> UserRoles { get; set; } = null!;
}