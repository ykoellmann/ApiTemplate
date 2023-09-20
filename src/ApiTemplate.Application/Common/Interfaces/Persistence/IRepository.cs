using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    public Task<List<TEntity>> GetAsync();
    
    public Task<TEntity> GetByIdAsync(TId id);

    public Task<TEntity> AddAsync(TEntity entity, UserId userId);
    
    public Task<TEntity> UpdateAsync(TEntity entity);
    
    public Task<Deleted> DeleteAsync(TId id);
}