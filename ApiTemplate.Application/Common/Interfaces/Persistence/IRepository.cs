using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.User.ValueObjects;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    public Task<ErrorOr<List<TEntity>>> Get();
    
    public Task<ErrorOr<TEntity>> GetById(TId id);

    public Task<ErrorOr<TEntity>> Add(TEntity entity, UserId userId);
    
    public Task<ErrorOr<TEntity>> Update(TEntity entity);
    
    public Task<ErrorOr<Deleted>> Delete(TId id);
}