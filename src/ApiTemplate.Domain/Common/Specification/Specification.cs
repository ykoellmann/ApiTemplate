using System.Linq.Expressions;
using System.Reflection;
using ApiTemplate.Domain.Common.Specification.Include;
using ApiTemplate.Domain.Common.Specification.Order;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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


        if (includable.ThenInclude)
        {
            var thenInclude = typeof(EntityFrameworkQueryableExtensions).GetMethod("ThenInclude",
                [typeof(IQueryable<TEntity>), includable.NavigationPropertyPath.GetType()])!;
            query = (IQueryable<TEntity>)thenInclude.Invoke(null, [query, includable.NavigationPropertyPath]);
        }
        else
        {
            query = IncludeProperty(query, includable.NavigationPropertyPath, includable.NavigationPropertyType);
        }

        return query;
    }

    private IQueryable<TEntity> IncludeProperty(IQueryable<TEntity> query, Expression navigationPropertyPath,
        Type navigationPropertyType)
    {
        
        
        // Get the Include method from the IQueryable<TEntity> interface
        var includeMethodInfo = typeof(EntityFrameworkQueryableExtensions).GetMethod("Include",
            [typeof(IQueryable<TEntity>), typeof(Expression<Func<TEntity, IReadOnlyList<RefreshToken>>>)])!;
        
        // Create a MethodInfo object that represents the Include method with the specific type parameters
        var genericIncludeMethodInfo = includeMethodInfo.MakeGenericMethod(typeof(TEntity), navigationPropertyType);

        // Call the Include method
        return (IQueryable<TEntity>)genericIncludeMethodInfo.Invoke(null, [query, navigationPropertyPath]);
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