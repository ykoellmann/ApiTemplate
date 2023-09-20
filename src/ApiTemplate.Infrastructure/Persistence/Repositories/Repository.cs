using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence.Repositories;

public class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    private readonly ApiTemplateDbContext _dbContext;
    
    public Repository(ApiTemplateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<List<TEntity>> GetAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> GetByIdAsync(TId id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, UserId userId)
    {
        entity.CreatedBy = userId;
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedBy = userId;
        entity.UpdatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<Deleted> DeleteAsync(TId id)
    {
        _dbContext.Set<TEntity>().Remove(_dbContext.Set<TEntity>().Find(id));
        _dbContext.SaveChangesAsync();

        return new Deleted();
    }
}