using ApiTemplate.Domain.Models;

namespace ApiTemplate.Application.Common.Events.Created;

public record CreatedEvent<TEntity, TId>(TEntity Created) : IDomainEvent
    where TEntity : Entity<TId> 
    where TId : IdObject<TId>;