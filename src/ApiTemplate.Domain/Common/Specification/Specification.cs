using System.Linq.Expressions;
using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Common.Specification;

public class Specification<TEntity, TId>
    where TEntity : Entity<TId> 
    where TId : IdObject<TId>
{
    public List<IncludeSpecification> Includes { get; } = new();
    public List<OrderBySpecification> OrderBy { get; set; }
    
    public ThenIncludeSpecification<TEntity, TProperty> AddInclude<TProperty>(Expression<Func<TEntity, TProperty>> includeExpression)
    {
        var include = new ThenIncludeSpecification<TEntity, TProperty>(includeExpression);
        Includes.Add(include);
        return include;
    }
    
    public ThenBySpecification<TEntity> AddOrderBy(Expression<Func<TEntity, object>> orderByExpression, bool descending = false)
    {
        var orderBy = new ThenBySpecification<TEntity>(orderByExpression, descending);
        OrderBy.Add(orderBy);
        return orderBy;
    }
}