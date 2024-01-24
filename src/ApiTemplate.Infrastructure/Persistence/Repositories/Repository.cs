using ApiTemplate.Application.Common.Events;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;
using ApiTemplate.Infrastructure.Extensions;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories;

public class Repository<TEntity, TId, TIDto> : IRepository<TEntity, TId, TIDto>
    where TEntity : Entity<TId>
    where TId : Id<TId>
    where TIDto : IDto<TId>
{
    private readonly ApiTemplateDbContext _dbContext;

    public Repository(ApiTemplateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken,
        Specification<TEntity, TId> specification = null)
    {
        return await _dbContext.Set<TEntity>()
            .Specificate(specification)
            .ToListAsync(cancellationToken);
    }
    
    public virtual async Task<List<TDto>> GetDtoListAsync<TDto>(CancellationToken cancellationToken)
        where TDto : Dto<TDto, TEntity, TId>, TIDto, new()
    {
        return await _dbContext.Set<TEntity>()
            .Select(new TDto().Projection())
            .ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken,
        Specification<TEntity, TId> specification = null)
    {
        return await _dbContext.Set<TEntity>()
            .Specificate(specification)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken: cancellationToken);
    }

    public virtual async Task<TDto?> GetDtoByIdAsync<TDto>(TId id, CancellationToken cancellationToken)
        where TDto : Dto<TDto, TEntity, TId>, TIDto, new()
    {
        return await _dbContext.Set<TEntity>()
            .Select(new TDto().Projection())
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken: cancellationToken);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, UserId userId, CancellationToken cancellationToken)
    {
        entity.CreatedBy = userId;
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedBy = userId;
        entity.UpdatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return await _dbContext.Set<TEntity>()
            .SingleAsync(e => e.Id == entity.Id, cancellationToken: cancellationToken);
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        entity.AddDomainEventAsync(new ClearCacheEvent<TEntity, TId>(entity));

        await _dbContext.SaveChangesAsync(cancellationToken);

        return await _dbContext.Set<TEntity>()
            .SingleAsync(e => e.Id == entity.Id, cancellationToken: cancellationToken);
    }

    public virtual async Task<Deleted> DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Set<TEntity>()
            .FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
        await entity.AddDomainEventAsync(new ClearCacheEvent<TEntity, TId>(entity));

        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new Deleted();
    }


    [Obsolete("This method is only available in the cached repository")]
    public Task ClearCacheAsync<TChanged>(TChanged changedEvent) where TChanged : ClearCacheEvent<TEntity, TId>
        => throw new NotImplementedException("This method is only available in the cached repository");
}