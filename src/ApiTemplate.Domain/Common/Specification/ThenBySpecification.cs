using System.Linq.Expressions;

namespace ApiTemplate.Domain.Common.Specification;

public class ThenBySpecification<TEntity> : OrderBySpecification
{
    public ThenBySpecification(Expression<Func<TEntity, object>> orderByExpression, bool descending)
    {
    }
    
    public ThenBySpecification<TEntity> AddThenBy(Expression<Func<TEntity, object>> orderByExpression, bool descending = false) 
    {
        var thenBySpecification = new ThenBySpecification<TEntity>(orderByExpression, descending);
        ThenBy.Add(thenBySpecification);
        return thenBySpecification;
    }
}