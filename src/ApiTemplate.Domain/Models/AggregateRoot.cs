namespace ApiTemplate.Domain.Models;

public abstract class AggregateRoot<TId> : Entity<TId> 
    where TId : IdObject<TId>
{
    protected AggregateRoot(TId id) : base(id)
    {
    }
    
    //Used for Json serialization
    protected AggregateRoot() : base()
    {
    }
}