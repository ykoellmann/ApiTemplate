using System.Linq.Expressions;
using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Common.Specification;

public interface ISpecification<TEntity, TId, TResult>
    where TEntity : Entity<TId>
    where TId : Id<TId>
{
    IQueryable<TResult> Specificate(IQueryable<TEntity> query);
}

public interface ISpecification<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>
{
    IQueryable<TEntity> Specificate(IQueryable<TEntity> query);
}
