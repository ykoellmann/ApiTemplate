using ApiTemplate.Domain.Idempotencies.ValueObjects;
using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Idempotencies;

public class Idempotency : Entity<IdempotencyId>
{
    public Idempotency(IdempotencyId idempotencyId, string requestName)
    {
        IdempotencyId = idempotencyId;
        RequestName = requestName;
    }

    public IdempotencyId IdempotencyId { get; }
    public string RequestName { get; set; }
}