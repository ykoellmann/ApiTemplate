using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Idempotencies;
using ApiTemplate.Domain.Idempotencies.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.Idempotencies;

public class IdempotencyRepository : Repository<Idempotency, IdempotencyId>, IIdempotencyRepository
{
    private readonly ApiTemplateDbContext _dbContext;

    public IdempotencyRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> RequestExistsAsync(IdempotencyId id, CancellationToken ct)
    {
        return _dbContext.Set<Idempotency>()
            .AnyAsync(x => x.Id == id, ct);
    }
}