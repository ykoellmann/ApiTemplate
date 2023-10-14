using ApiTemplate.Application.Common.Interfaces.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Models;
using MediatR;

namespace ApiTemplate.Application.Common.EventHandlers;

public class UpdatedEventHandler<TIRepository, TEntity, TId, TUpdated> : IEventHandler<TUpdated> 
    where TUpdated : UpdatedEvent<TEntity, TId>
    where TIRepository : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    private readonly TIRepository _repository;

    public UpdatedEventHandler(TIRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(TUpdated notification, CancellationToken cancellationToken)
    {
        var _cacheKeys = await GetCacheKeysAsync(notification);
        
        _cacheKeys.Add(await _repository.EntityValueCacheKeyAsync(nameof(_repository.GetByIdAsync), notification.Updated.Id.Value.ToString()));
        
        await _repository.ClearCacheAsync(_cacheKeys);
    }

    public virtual async Task<List<string>> GetCacheKeysAsync(TUpdated notification)
    {
        return new List<string>();
    }
}