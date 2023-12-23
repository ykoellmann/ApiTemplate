using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Models;
using MediatR;

namespace ApiTemplate.Application.Common.EventHandlers;

public class DeletedEventHandler<TIRepository, TEntity, TId, TIDto, TDeleted> : INotificationHandler<TDeleted> 
    where TDeleted : DeletedEvent<TEntity, TId>
    where TIRepository : IRepository<TEntity, TId, TIDto>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
    where TIDto : IDto<TId>
{
    private readonly TIRepository _repository;
    private List<string>? _cacheKeys;
    
    public DeletedEventHandler(TIRepository repository)
    {
        _repository = repository;
    }

    public Task Handle(TDeleted deletedEvent, CancellationToken cancellationToken)
    {
        var _cacheKeys = GetBaseCacheKeysAsync(deletedEvent);

        return _repository.ClearCacheAsync(_cacheKeys);
    }

    private async IAsyncEnumerable<string> GetBaseCacheKeysAsync(TDeleted deletedEvent)
    {
        yield return await _repository.EntityValueCacheKeyAsync(nameof(_repository.GetByIdAsync),
            deletedEvent.Deleted.Id.Value.ToString());
        yield return await _repository.EntityCacheKeyAsync(nameof(_repository.GetListAsync));
        
        await foreach (var cacheKey in GetCacheKeysAsync(deletedEvent))
        {
            yield return cacheKey;
        }
    }

    protected virtual IAsyncEnumerable<string> GetCacheKeysAsync(TDeleted deletedEvent)
    {
        throw new NotImplementedException("Override this method to add additional cache keys.");
    }
}