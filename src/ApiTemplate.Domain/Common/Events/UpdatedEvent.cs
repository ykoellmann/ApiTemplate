using ApiTemplate.Domain.Models;
using MediatR;

namespace ApiTemplate.Domain.Common.Events;

public record UpdatedEvent<TEntity, TId>(TEntity Updated) : IDomainEvent 
    where TEntity : Entity<TId> 
    where TId : IdObject<TId>;