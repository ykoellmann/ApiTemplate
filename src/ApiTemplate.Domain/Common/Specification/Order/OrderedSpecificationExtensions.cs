using System.Linq.Expressions;

namespace ApiTemplate.Domain.Common.Specification.Order;

public static class OrderedSpecificationExtensions
{
    public static IOrderedSpecification<TEntity> OrderBy<TEntity, TProperty>(
        this IOrderedSpecification<TEntity> source, 
        Expression<Func<TEntity, TProperty>> orderBy)
        where TEntity : class
    {
        return null;
    }
    
    public static IOrderedSpecification<TEntity> OrderByDescending<TEntity, TProperty>(
        this IOrderedSpecification<TEntity> source, 
        Expression<Func<TEntity, TProperty>> orderByDescending) 
        where TEntity : class
    {
        return null;
    }
}