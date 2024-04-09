using System.Linq.Expressions;

namespace ApiTemplate.Domain.Common.Specification.Include;

public static class IncludableSpecificationExtensions
{
    public static IIncludableSpecification<TEntity, TProperty> Include<TEntity, TProperty>(
        this IIncludableSpecification<TEntity> source,
        Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        where TEntity : class
        where TProperty : class
    {
        return new IncludableSpecification<TEntity, TProperty>(navigationPropertyPath, false, source);
    }

    public static IIncludableSpecification<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludableSpecification<TEntity, IReadOnlyList<TPreviousProperty>> source,
        Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
        where TEntity : class
        where TPreviousProperty : class
        where TProperty : class
    {
        return new IncludableSpecification<TEntity, TProperty>(navigationPropertyPath, true, source);
    }

    public static IIncludableSpecification<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludableSpecification<TEntity, TPreviousProperty> source,
        Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
        where TEntity : class
        where TPreviousProperty : class
        where TProperty : class
    {
        return new IncludableSpecification<TEntity, TProperty>(navigationPropertyPath, true, source);
    }
}