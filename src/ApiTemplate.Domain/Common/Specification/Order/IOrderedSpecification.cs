using System.Linq.Expressions;

namespace ApiTemplate.Domain.Common.Specification.Order;

public interface IOrderedSpecification<TEntity>
    where TEntity : class
{
    public IOrderedSpecification<TEntity>? Sub { get; protected set; }
    public Expression NavigationPropertyPath { get; protected set; }
    public bool IsDescending { get; protected set; }
    
    abstract static IOrderedSpecification<TEntity> OrderBy<TProperty>(
        Expression<Func<TEntity, TProperty>> orderBy);
    
    abstract static IOrderedSpecification<TEntity> OrderByDescending<TProperty>(
        Expression<Func<TEntity, TProperty>> orderByDescending);
    
    //ThenBy
    IOrderedSpecification<TEntity> ThenBy<TProperty>(
        Expression<Func<TEntity, TProperty>> thenBy);
    
    //ThenByDescending
    IOrderedSpecification<TEntity> ThenByDescending<TProperty>(
        Expression<Func<TEntity, TProperty>> thenByDescending);
}