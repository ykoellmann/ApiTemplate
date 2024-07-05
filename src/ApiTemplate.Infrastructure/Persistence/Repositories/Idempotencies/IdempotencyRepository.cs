using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Idempotencies;
using ApiTemplate.Domain.Idempotencies.ValueObjects;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.Idempotencies;

public class IdempotencyRepository : Repository<Idempotency, IdempotencyId>, IIdempotencyRepository
{
    public IdempotencyRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> RequestExistsAsync(IdempotencyId id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task SaveRequestAsync(IdempotencyId id, string requestName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}