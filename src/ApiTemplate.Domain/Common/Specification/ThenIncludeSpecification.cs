using System.Linq.Expressions;

namespace ApiTemplate.Domain.Common.Specification;

public class ThenIncludeSpecification<TEntity, TProperty> : IncludeSpecification 
{
    public ThenIncludeSpecification(Expression<Func<TEntity, TProperty>> includeExpression)
    {
        IncludeExpression = includeExpression;
    }
    
    public ThenIncludeSpecification<TProperty, TSubProperty> ThenInclude<TSubProperty>(Expression<Func<TProperty, TSubProperty>> includeExpression) 
    {
        var thenInclude = new ThenIncludeSpecification<TProperty, TSubProperty>(includeExpression);
        ThenIncludes.Add(thenInclude);
        return thenInclude;
    }
}