using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Models;
using MediatR;

namespace ApiTemplate.Application.Common.EventHandlers;

public class CreatedEventHandler<TIRepository, TEntity, TId, TIDto, TCreated> : INotificationHandler<TCreated> 
    where TCreated : CreatedEvent<TEntity, TId>
    where TIRepository : IRepository<TEntity, TId, TIDto>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
    where TIDto : IDto<TId>
{
    private readonly TIRepository _repository;

    public CreatedEventHandler(TIRepository repository)
    {
        _repository = repository;
    }

    public Task Handle(TCreated notification, CancellationToken cancellationToken)
    {
        var _cacheKeys = GetBaseCacheKeysAsync(notification);

        return _repository.ClearCacheAsync(_cacheKeys);
    }

    private async IAsyncEnumerable<string> GetBaseCacheKeysAsync(TCreated createdEvent)
    {
        yield return await _repository.EntityValueCacheKeyAsync(nameof(_repository.GetByIdAsync),
            createdEvent.Created.Id.Value.ToString());
        yield return await _repository.EntityCacheKeyAsync(nameof(_repository.GetListAsync));
        
        await foreach (var cacheKey in GetCacheKeysAsync(createdEvent))
        {
            yield return cacheKey;
        }
    }

    protected virtual IAsyncEnumerable<string> GetCacheKeysAsync(TCreated createdEvent)
    {
        throw new NotImplementedException("Override this method to add additional cache keys.");
    }
}