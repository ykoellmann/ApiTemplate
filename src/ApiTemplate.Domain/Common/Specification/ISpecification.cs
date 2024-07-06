using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Common.Specification;

public interface ISpecification<in TEntity, TId, out TResult>
    where TEntity : Entity<TId>
    where TId : Id<TId>, new()
{
    IQueryable<TResult> Specificate(IQueryable<TEntity> query);
}

public interface ISpecification<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>, new()
{
    IQueryable<TEntity> Specificate(IQueryable<TEntity> query);
}