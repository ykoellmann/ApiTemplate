using System.Linq.Expressions;

namespace ApiTemplate.Domain.Common.Specification.Include;

// public class IncludableSpecification : IIncludableSpecification
// {
//     public IncludableSpecification(Expression navigationPropertyPath)
//     {
//         NavigationPropertyPath = navigationPropertyPath;
//     }
//     public IncludableSpecification(Expression navigationPropertyPath, IIncludableSpecification? sub)
//     {
//         NavigationPropertyPath = navigationPropertyPath;
//         Sub = sub;
//     }
//
//     public Expression NavigationPropertyPath { get; set; }
//     public IIncludableSpecification? Sub { get; set; }
// }

public class IncludableSpecification<TEntity> : IIncludableSpecification<TEntity>
    where TEntity : class
{
    
    public IncludableSpecification(Expression navigationPropertyPath)
    {
        NavigationPropertyPath = navigationPropertyPath;
    }
    public IncludableSpecification(Expression navigationPropertyPath, IIncludableSpecification<TEntity>? sub)
    {
        NavigationPropertyPath = navigationPropertyPath;
        Sub = sub;
    }

    public IIncludableSpecification<TEntity>? Sub { get; set; }
    public Expression NavigationPropertyPath { get; set; }

    public static IIncludableSpecification<TEntity, TProperty> Include<TProperty>(
        Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        where TProperty : class
    {
        return new IncludableSpecification<TEntity, TProperty>(navigationPropertyPath);
    }
}

public class IncludableSpecification<TEntity, TProperty> : IncludableSpecification<TEntity>,
    IIncludableSpecification<TEntity, TProperty>
    where TEntity : class
{
    public IncludableSpecification(Expression navigationPropertyPath) : base(navigationPropertyPath)
    {
    }

    public IncludableSpecification(Expression navigationPropertyPath, IIncludableSpecification<TEntity>? sub) : base(navigationPropertyPath, sub)
    {
    }
}