using ApiTemplate.Domain.Models;

namespace ApiTemplate.Application.Common.Events;

public record ClearCacheEvent<TEntity, TId>(TEntity Changed) : IDomainEvent
    where TEntity : Entity<TId>
    where TId : Id<TId>, new();