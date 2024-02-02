using ApiTemplate.Application.Common.Events;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;
using ApiTemplate.Infrastructure.Extensions;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories;

public class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>
{
    private readonly ApiTemplateDbContext _dbContext;

    public Repository(ApiTemplateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<List<TEntity>> GetListAsync(CancellationToken ct,
        Specification<TEntity, TId> specification = null)
    {
        return await _dbContext.Set<TEntity>()
            .Specificate(specification)
            .ToListAsync(ct);
    }
    
    public virtual async Task<List<TDto>> GetDtoListAsync<TDto>(CancellationToken ct)
        where TDto : IDto<TDto, TEntity, TId>, new()
    {
        return await _dbContext.Set<TEntity>()
            .Select(TDto.Map())
            .ToListAsync(ct);
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct,
        Specification<TEntity, TId> specification = null)
    {
        return await _dbContext.Set<TEntity>()
            .Specificate(specification)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken: ct);
    }

    public virtual async Task<TDto?> GetDtoByIdAsync<TDto>(TId id, CancellationToken ct)
        where TDto : IDto<TDto, TEntity, TId>, new()
    {
        return await _dbContext.Set<TEntity>()
            .Select(TDto.Map())
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken: ct);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, UserId userId, CancellationToken ct)
    {
        entity.CreatedBy = userId;
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedBy = userId;
        entity.UpdatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(entity, ct);
        await _dbContext.SaveChangesAsync(ct);

        return await _dbContext.Set<TEntity>()
            .SingleAsync(e => e.Id == entity.Id, cancellationToken: ct);
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct)
    {
        entity.AddDomainEventAsync(new ClearCacheEvent<TEntity, TId>(entity));

        await _dbContext.SaveChangesAsync(ct);

        return await _dbContext.Set<TEntity>()
            .SingleAsync(e => e.Id == entity.Id, cancellationToken: ct);
    }

    public virtual async Task<Deleted> DeleteAsync(TId id, CancellationToken ct)
    {
        var entity = await _dbContext.Set<TEntity>()
            .FindAsync(new object?[] { id }, cancellationToken: ct);
        await entity.AddDomainEventAsync(new ClearCacheEvent<TEntity, TId>(entity));

        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(ct);

        return new Deleted();
    }


    [Obsolete("This method is only available in the cached repository")]
    public Task ClearCacheAsync<TChanged>(TChanged changedEvent) where TChanged : ClearCacheEvent<TEntity, TId>
        => throw new NotImplementedException("This method is only available in the cached repository");
}