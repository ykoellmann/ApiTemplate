using System.Linq.Expressions;
using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Common.Specification;

public interface ISpecification<TEntity, TId, TResult>
    where TEntity : Entity<TId>
    where TId : Id<TId>
{
    Expression<Func<TEntity, TResult>> Map();
}

public interface ISpecification<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>
{
}


