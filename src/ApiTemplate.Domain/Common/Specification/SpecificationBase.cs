using ApiTemplate.Domain.Common.Specification.Include;
using ApiTemplate.Domain.Common.Specification.Order;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users;

namespace ApiTemplate.Domain.Common.Specification;

public class SpecificationBase<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>, new()
{
    protected virtual bool AsNoTracking => false;
    protected virtual bool AsSplitQuery => false;
    protected virtual bool IgnoreQueryFilters => false;

    protected virtual IIncludableSpecification<TEntity> Include(IIncludableSpecification<TEntity> includable)
    {
        return null;
    }

    protected virtual IOrderedSpecification<TEntity> Order(IOrderedSpecification<TEntity> ordered)
    {
        return null;
    }
}