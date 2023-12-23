using System.Linq.Expressions;

namespace ApiTemplate.Domain.Models;

public abstract class Dto<TDto, TEntity, TId>
    where TDto : IDto<TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    public abstract Expression<Func<TEntity, TDto>> Projection();
}