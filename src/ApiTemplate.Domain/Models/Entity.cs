using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Models;

public class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents
    where TId : Id<TId>, new()
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity()
    {
        Id = new TId();
    }


    [Column(Order = 0)] 
    public TId Id { get; }

    [Column(Order = 9996)] 
    public virtual UserId CreatedBy { get; set; } = null!;

    [Column(Order = 9997)] 
    public virtual DateTime CreatedAt { get; set; }

    [Column(Order = 9998)] 
    public virtual UserId UpdatedBy { get; set; } = null!;

    [Column(Order = 9999)] 
    public virtual DateTime UpdatedAt { get; set; }


    public virtual User CreatedByUser { get; set; } = null!;
    public virtual User UpdatedByUser { get; set; } = null!;

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public void AddDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
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