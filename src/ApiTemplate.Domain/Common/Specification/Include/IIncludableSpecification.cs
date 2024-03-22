using System.Linq.Expressions;

namespace ApiTemplate.Domain.Common.Specification.Include;

// public interface IIncludableSpecification
// {
//     public IIncludableSpecification? Sub { get; protected set; }
//     public Expression NavigationPropertyPath { get; protected set; }
// }

public interface IIncludableSpecification<TEntity>
    where TEntity : class
{
    
    public IIncludableSpecification<TEntity>? Sub { get; protected set; }
    public Expression NavigationPropertyPath { get; protected set; }
    
    static abstract IIncludableSpecification<TEntity, TProperty> Include<TProperty>(
        Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        where TProperty : class;
}

public interface IIncludableSpecification<TEntity, TProperty> : IIncludableSpecification<TEntity>
    where TEntity : class
{
    
}