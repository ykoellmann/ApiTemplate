using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Common.Specification;

public abstract class Specification<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IdObject<TId>
{
    public abstract IQueryable<TEntity> Specificate(IQueryable<TEntity> query);
}