using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    public Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken, Specification<TEntity, TId> specification = null);
    
    public Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken, Specification<TEntity, TId> specification = null);

    public Task<TEntity> AddAsync(TEntity entity, UserId userId, CancellationToken cancellationToken);
    
    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    
    public Task<Deleted> DeleteAsync(TId id, CancellationToken cancellationToken);
    
    public Task ClearCacheAsync(IAsyncEnumerable<string> cacheKeys = null);
    public Task<string> EntityValueCacheKeyAsync(string usage, string value);
}