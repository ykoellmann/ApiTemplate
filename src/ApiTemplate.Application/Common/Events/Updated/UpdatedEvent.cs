using ApiTemplate.Domain.Models;

namespace ApiTemplate.Application.Common.Events.Updated;

public record UpdatedEvent<TEntity, TId>(TEntity Updated) : IDomainEvent 
    where TEntity : Entity<TId> 
    where TId : IdObject<TId>;