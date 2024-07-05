using ApiTemplate.Domain.Idempotencies;
using ApiTemplate.Domain.Idempotencies.ValueObjects;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IIdempotencyRepository : IRepository<Idempotency, IdempotencyId>
{
    Task<bool> RequestExistsAsync(IdempotencyId idempotencyId, CancellationToken ct);
}