using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    public Task<List<TEntity>> Get();
    
    public Task<TEntity> GetById(TId id);

    public Task<TEntity> Add(TEntity entity, UserId userId);
    
    public Task<TEntity> Update(TEntity entity);
    
    public Task<Deleted> Delete(TId id);
}