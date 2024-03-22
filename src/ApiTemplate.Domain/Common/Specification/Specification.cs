using System.Linq.Expressions;
using ApiTemplate.Domain.Common.Specification.Include;
using ApiTemplate.Domain.Common.Specification.Order;
using ApiTemplate.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Domain.Common.Specification;

// Mapping of DTO, Include, OrderBy, Tracking, AsNoTracking, AsSplitQuery, IgnoreQueryFilters, 

public abstract class Specification<TEntity, TId, TDto> : Specification<TEntity, TId>,
    ISpecification<TEntity, TId, TDto>
    where TEntity : Entity<TId>
    where TId : Id<TId>
{
    public abstract Expression<Func<TEntity, TDto>> Map();

    public new IQueryable<TDto> Specificate(IQueryable<TEntity> query)
    {
        query = base.Specificate(query);

        return query.Select(Map());
    }
}

public class Specification<TEntity, TId> : ISpecification<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>
{
    protected virtual bool AsNoTracking => false;
    protected virtual bool AsSplitQuery => false;
    protected virtual bool IgnoreQueryFilters => false;

    public IQueryable<TEntity> Specificate(IQueryable<TEntity> query)
    {
        if (Include() is IIncludableSpecification<TEntity> includable)
        {
            query = Include(query, includable);
        }

        if (Order() is IOrderedSpecification<TEntity> ordered)
        {
            query = Order(query, ordered);
        }

        if (AsNoTracking) query = query.AsNoTracking();

        if (AsSplitQuery) query = query.AsSplitQuery();

        if (IgnoreQueryFilters) query = query.IgnoreQueryFilters();

        return query;
    }


    public virtual IIncludableSpecification<TEntity> Include()
    {
        return null;
    }

    private IQueryable<TEntity> Include(IQueryable<TEntity> query, IIncludableSpecification<TEntity> includable)
    {
        if (includable.Sub is IIncludableSpecification<TEntity> sub)
        {
            Include(query, sub);
        }

        query.Include(includable.NavigationPropertyPath.ToString());

        return query;
    }

    public virtual IOrderedSpecification<TEntity> Order()
    {
        return null;
    }

    public IQueryable<TEntity> Order(IQueryable<TEntity> query, IOrderedSpecification<TEntity> ordered)
    {
        var isLast = true;
        if (ordered.Sub is IOrderedSpecification<TEntity> sub)
        {
            query = Order(query, sub);
            isLast = false;
        }

        if (isLast)
        {
            query = ordered.IsDescending
                ? query.OrderByDescending(entity => ordered.NavigationPropertyPath)
                : query.OrderBy(entity => ordered.NavigationPropertyPath);
        }
        else
        {
            query = ordered.IsDescending
                ? ((IOrderedQueryable<TEntity>)query).ThenByDescending(entity => ordered.NavigationPropertyPath)
                : ((IOrderedQueryable<TEntity>)query).ThenBy(entity => ordered.NavigationPropertyPath);
        }

        return query;
    }
}