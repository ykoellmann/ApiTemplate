namespace PawPal.Domain.Models;

public abstract class AggregateRoot<TId> : Entity<TId> 
    where TId : IdObject<TId>
{
    protected AggregateRoot(TId id) : base(id)
    {
    }
}