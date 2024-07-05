namespace ApiTemplate.Domain.Models;

public abstract class AggregateRoot<TId> : Entity<TId> 
    where TId : Id<TId>, new();