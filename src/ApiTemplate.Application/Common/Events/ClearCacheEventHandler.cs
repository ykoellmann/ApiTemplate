using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Models;
using MediatR;

namespace ApiTemplate.Application.Common.Events;

public class ClearCacheEventHandler<TIRepository, TEntity, TId, TIDto, TChanged> : INotificationHandler<TChanged> 
    where TChanged : ClearCacheEvent<TEntity, TId>
    where TIRepository : IRepository<TEntity, TId, TIDto>
    where TEntity : Entity<TId>
    where TId : Id<TId>
    where TIDto : IDto<TId>
{
    private readonly TIRepository _repository;

    public ClearCacheEventHandler(TIRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(TChanged changedEvent, CancellationToken ct)
    {
        await _repository.ClearCacheAsync(changedEvent);
    }
}