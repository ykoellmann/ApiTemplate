using ApiTemplate.Application.Common.Events;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IRepository<TEntity, TId, TIDto>
    where TEntity : Entity<TId>
    where TId : Id<TId>
    where TIDto : IDto<TId>
{
    public Task<List<TEntity>> GetListAsync(CancellationToken ct, Specification<TEntity, TId> specification = null);
    public Task<List<TDto>> GetDtoListAsync<TDto>(CancellationToken ct)
        where TDto : Dto<TDto, TEntity, TId>, TIDto, new();
    
    public Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct, Specification<TEntity, TId> specification = null);

    Task<TDto?> GetDtoByIdAsync<TDto>(TId id, CancellationToken ct)
        where TDto : Dto<TDto, TEntity, TId>, TIDto, new();

    public Task<TEntity> AddAsync(TEntity entity, UserId userId, CancellationToken ct);
    
    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct);
    
    public Task<Deleted> DeleteAsync(TId id, CancellationToken ct);

    public Task ClearCacheAsync<TChanged>(TChanged changedEvent)
        where TChanged : ClearCacheEvent<TEntity, TId>;
}