using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Common.Events;

public record CreatedEvent<TEntity, TId>(TEntity Created) : IDomainEvent
    where TEntity : Entity<TId> 
    where TId : IdObject<TId>;