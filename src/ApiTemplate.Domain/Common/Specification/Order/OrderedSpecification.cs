using System.Linq.Expressions;

namespace ApiTemplate.Domain.Common.Specification.Order;

public class OrderedSpecification<TEntity> : IOrderedSpecification<TEntity>
    where TEntity : class
{
    public OrderedSpecification(Expression navigationPropertyPath, bool isDescending)
    {
        NavigationPropertyPath = navigationPropertyPath;
        IsDescending = isDescending;
    }

    public OrderedSpecification(Expression navigationPropertyPath, bool isDescending,
        IOrderedSpecification<TEntity>? sub)
    {
        NavigationPropertyPath = navigationPropertyPath;
        IsDescending = isDescending;
        Sub = sub;
    }

    public Expression NavigationPropertyPath { get; set; }
    public bool IsDescending { get; set; }
    public IOrderedSpecification<TEntity>? Sub { get; set; }

    public static IOrderedSpecification<TEntity> OrderBy<TProperty>(Expression<Func<TEntity, TProperty>> orderBy)
    {
        return new OrderedSpecification<TEntity>(orderBy, false);
    }

    public static IOrderedSpecification<TEntity> OrderByDescending<TProperty>(
        Expression<Func<TEntity, TProperty>> orderByDescending)
    {
        return new OrderedSpecification<TEntity>(orderByDescending, true);
    }

    public IOrderedSpecification<TEntity> ThenBy<TProperty>(Expression<Func<TEntity, TProperty>> thenBy)
    {
        return new OrderedSpecification<TEntity>(thenBy, false, this);
    }

    public IOrderedSpecification<TEntity> ThenByDescending<TProperty>(
        Expression<Func<TEntity, TProperty>> thenByDescending)
    {
        return new OrderedSpecification<TEntity>(thenByDescending, true, this);
    }
}