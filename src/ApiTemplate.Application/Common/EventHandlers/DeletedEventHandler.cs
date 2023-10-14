using ApiTemplate.Application.Common.Interfaces.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Models;
using MediatR;

namespace ApiTemplate.Application.Common.EventHandlers;

public class DeletedEventHandler<TIRepository, TEntity, TId, TDeleted> : IEventHandler<TDeleted> 
    where TDeleted : DeletedEvent<TEntity, TId>
    where TIRepository : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    private readonly TIRepository _repository;
    private List<string>? _cacheKeys;
    
    public DeletedEventHandler(TIRepository repository, List<string>? cacheKeys = null)
    {
        _repository = repository;
        _cacheKeys = cacheKeys;
    }
    
    public Task Handle(TDeleted notification, CancellationToken cancellationToken)
    {
        _cacheKeys ??= new List<string>();
        
        _cacheKeys.Add(_repository.EntityValueCacheKeyAsync(nameof(_repository.GetByIdAsync), notification.Deleted.Id.Value.ToString()).Result);
        
        return _repository.ClearCacheAsync(_cacheKeys);
    }

    public virtual async Task<List<string>> GetCacheKeys(TDeleted notification)
    {
        return new List<string>();
    }
}