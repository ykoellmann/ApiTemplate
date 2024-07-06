using ApiTemplate.Application.Common.Events;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>, new()
{
    Task<List<TEntity>> GetListAsync(CancellationToken ct,
        Specification<TEntity, TId>? specification = null);

    Task<List<TDto>> GetListAsync<TDto>(CancellationToken ct,
        Specification<TEntity, TId, TDto> specification)
        where TDto : IDto<TId>;

    Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct,
        Specification<TEntity, TId>? specification = null);

    Task<TDto?> GetByIdAsync<TDto>(TId id, CancellationToken ct,
        Specification<TEntity, TId, TDto> specification)
        where TDto : IDto<TId>;

    public Task<TEntity> AddAsync(TEntity entity, UserId userId, CancellationToken ct);

    public Task<TEntity> UpdateAsync(TEntity entity, UserId userId, CancellationToken ct);

    public Task<Deleted> DeleteAsync(TId id, CancellationToken ct);

    public Task ClearCacheAsync<TChanged>(TChanged changedEvent)
        where TChanged : ClearCacheEvent<TEntity, TId>;
}