using System.Linq.Expressions;
using ApiTemplate.Domain.Common.Specification;

namespace ApiTemplate.Infrastructure.Extensions;

public static class ThenIncludeSpecificationExtensions
{
    public static ThenIncludeSpecification<TProperty, TSubProperty> AddThenInclude<TEntity, TProperty, TSubProperty>(this ThenIncludeSpecification<TEntity, IReadOnlyList<TProperty>> specification, Expression<Func<TProperty, TSubProperty>> includeExpression)
    {
        var thenInclude = new ThenIncludeSpecification<TProperty, TSubProperty>(includeExpression);
        specification.ThenIncludes.Add(thenInclude);
        return thenInclude;
    }
}