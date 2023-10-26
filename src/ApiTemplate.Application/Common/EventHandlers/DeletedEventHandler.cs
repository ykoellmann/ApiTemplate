using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
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
    
    public DeletedEventHandler(TIRepository repository)
    {
        _repository = repository;
    }
    
    public Task Handle(TDeleted notification, CancellationToken cancellationToken)
    {
        var cacheKeys = GetCacheKeysAsync(notification);
        
        return _repository.ClearCacheAsync(cacheKeys);
    }

    protected virtual async IAsyncEnumerable<string> GetCacheKeysAsync(TDeleted notification)
    {
        yield return await _repository.EntityValueCacheKeyAsync(nameof(_repository.GetByIdAsync),
            notification.Deleted.Id.Value.ToString());
    }
}