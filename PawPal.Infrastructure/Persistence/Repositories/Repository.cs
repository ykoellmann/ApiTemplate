using ErrorOr;
using Microsoft.EntityFrameworkCore;
using PawPal.Application.Common.Interfaces.Persistence;
using PawPal.Domain.Models;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Repositories;

public class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    private readonly PawPalDbContext _dbContext;
    
    public Repository(PawPalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<List<TEntity>>> Get()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<ErrorOr<TEntity>> GetById(TId id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<ErrorOr<TEntity>> Add(TEntity entity, UserId userId)
    {
        entity.CreatedBy = userId;
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedBy = userId;
        entity.UpdatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return entity;
    }

    public async Task<ErrorOr<TEntity>> Update(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<ErrorOr<Deleted>> Delete(TId id)
    {
        _dbContext.Set<TEntity>().Remove(_dbContext.Set<TEntity>().Find(id));
        _dbContext.SaveChangesAsync();

        return new Deleted();
    }
}