using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.User.ValueObjects;

namespace ApiTemplate.Domain.Models;

public class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents
    where TId : IdObject<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    
    
    [Column(Order = 0)]
    public TId Id { get; set; }
    
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
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    public async Task ClearDomainEventsAsync()
    {
        _domainEvents.Clear();
    }

    protected Entity(TId id)
    {
        Id = id;
    }

    //Used for Json serialization
    protected Entity()
    {
        
    }
    
    public async Task AddDomainEventAsync(IDomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

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