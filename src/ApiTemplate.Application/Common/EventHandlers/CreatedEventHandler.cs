using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Models;
using MediatR;

namespace ApiTemplate.Application.Common.EventHandlers;

public class CreatedEventHandler<TIRepository, TEntity, TId, TCreated> : IEventHandler<TCreated> 
    where TCreated : CreatedEvent<TEntity, TId>
    where TIRepository : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    private readonly TIRepository _repository;

    public CreatedEventHandler(TIRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(TCreated notification, CancellationToken cancellationToken)
    {
        var _cacheKeys = GetCacheKeysAsync(notification);
        
        await _repository.ClearCacheAsync(_cacheKeys);
    }

    protected virtual async IAsyncEnumerable<string> GetCacheKeysAsync(TCreated notification)
    {
        yield return await _repository.EntityValueCacheKeyAsync(nameof(_repository.GetByIdAsync),
            notification.Created.Id.Value.ToString());
        yield return await _repository.EntityCacheKeyAsync(nameof(_repository.GetListAsync));
    }
}