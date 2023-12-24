using ApiTemplate.Domain.Models;

namespace ApiTemplate.Application.Common.Events.Deleted;

public record DeletedEvent<TEntity, TId>(TEntity Deleted) : IDomainEvent
    where TEntity : Entity<TId>
    where TId : IdObject<TId>;