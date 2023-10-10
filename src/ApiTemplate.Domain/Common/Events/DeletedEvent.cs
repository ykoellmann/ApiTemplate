using ApiTemplate.Domain.Models;
using MediatR;

namespace ApiTemplate.Domain.Common.Events;

public record DeletedEvent<TEntity, TId>(TEntity Deleted) : IDomainEvent
    where TEntity : Entity<TId>
    where TId : IdObject<TId>;