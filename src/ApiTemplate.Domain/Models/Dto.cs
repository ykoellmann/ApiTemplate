using System.Linq.Expressions;

namespace ApiTemplate.Domain.Models;

public abstract class Dto<TDto, TEntity, TId>
    where TDto : IDto<TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>
{
    public abstract Expression<Func<TEntity, TDto>> Projection();
}