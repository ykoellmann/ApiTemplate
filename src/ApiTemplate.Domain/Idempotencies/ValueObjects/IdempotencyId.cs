using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Idempotencies.ValueObjects;

public class IdempotencyId : Id<IdempotencyId>
{
    public IdempotencyId()
    {
    }
    
    public IdempotencyId(Guid value) : base(value)
    {
    }
}