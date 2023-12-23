using System.Linq.Expressions;

namespace ApiTemplate.Domain.Models;

public interface IDto<TId>
    where TId : IdObject<TId>
{
    TId Id { get; set; }
}