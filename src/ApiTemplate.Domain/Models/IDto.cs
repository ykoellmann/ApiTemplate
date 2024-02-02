using System.Linq.Expressions;

namespace ApiTemplate.Domain.Models;

public interface IDto<TDto, TEntity, TId>
    where TDto : IDto<TDto, TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>
{
    TId Id { get; set; }
    static abstract Expression<Func<TEntity, TDto>> Map();
}