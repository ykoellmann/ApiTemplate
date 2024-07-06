using System.Linq.Expressions;

namespace ApiTemplate.Domain.Common.Specification.Order;

public interface IOrderedSpecification<TEntity>
    where TEntity : class
{
    IOrderedSpecification<TEntity> OrderBy<TProperty>(
        Expression<Func<TEntity, TProperty>> orderBy);

    IOrderedSpecification<TEntity> OrderByDescending<TProperty>(
        Expression<Func<TEntity, TProperty>> orderByDescending);

    IOrderedSpecification<TEntity> ThenBy<TProperty>(
        Expression<Func<TEntity, TProperty>> thenBy);

    IOrderedSpecification<TEntity> ThenByDescending<TProperty>(
        Expression<Func<TEntity, TProperty>> thenByDescending);
}