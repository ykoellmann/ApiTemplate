using System.Linq.Expressions;

namespace ApiTemplate.Domain.Models;

public interface IDto<TId>
    where TId : Id<TId>
{
    TId Id { get; set; }
}