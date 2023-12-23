using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Models;
using MediatR;

namespace ApiTemplate.Application.Common.EventHandlers;

public class UpdatedEventHandler<TIRepository, TEntity, TId, TIDto, TUpdated> : INotificationHandler<TUpdated> 
    where TUpdated : UpdatedEvent<TEntity, TId>
    where TIRepository : IRepository<TEntity, TId, TIDto>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
    where TIDto : IDto<TId>
{
    private readonly TIRepository _repository;

    public UpdatedEventHandler(TIRepository repository)
    {
        _repository = repository;
    }

    public Task Handle(TUpdated updatedEvent, CancellationToken cancellationToken)
    {
        var _cacheKeys = GetBaseCacheKeysAsync(updatedEvent);

        return _repository.ClearCacheAsync(_cacheKeys);
    }

    private async IAsyncEnumerable<string> GetBaseCacheKeysAsync(TUpdated updatedEvent)
    {
        yield return await _repository.EntityValueCacheKeyAsync(nameof(_repository.GetByIdAsync),
            updatedEvent.Updated.Id.Value.ToString());
        yield return await _repository.EntityCacheKeyAsync(nameof(_repository.GetListAsync));
        
        await foreach (var cacheKey in GetCacheKeysAsync(updatedEvent))
        {
            yield return cacheKey;
        }
    }

    protected virtual IAsyncEnumerable<string> GetCacheKeysAsync(TUpdated updatedEvent)
    {
        throw new NotImplementedException("Override this method to add additional cache keys.");
    }
}