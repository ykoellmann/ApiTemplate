using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Domain.Models;

public class Entity<TId> : IEquatable<Entity<TId>>
    where TId : IdObject<TId>
{
    [Column(Order = 9996)]
    public virtual UserId CreatedBy { get; set; }
    
    [Column(Order = 9997)]
    public virtual DateTime CreatedAt { get; set; }
    
    [Column(Order = 9998)]
    public virtual UserId UpdatedBy { get; set; }
    
    [Column(Order = 9999)]
    public virtual DateTime UpdatedAt { get; set; }
    
    public virtual User.User CreatedByUser { get; set; }
    public virtual User.User UpdatedByUser { get; set; }
    
    protected Entity(TId id)
    {
        Id = id;
    }

    [Column(Order = 0)]
    public TId Id { get; set; }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}