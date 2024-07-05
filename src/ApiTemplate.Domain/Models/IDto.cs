namespace ApiTemplate.Domain.Models;

public interface IDto<TId>
    where TId : Id<TId>, new()
{
    TId Id { get; init; }
}