using System.Linq.Expressions;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> ApplySpecification<TEntity, TId>(this IQueryable<TEntity> query, Specification<TEntity, TId> specification)
        where TEntity : Entity<TId>
        where TId : IdObject<TId>
    {
        if (specification is null)
            return query;
        
        specification.Includes.ForEach(include =>
        {
            query = ApplyInclude(query, include);
        });
        
        specification.OrderBy.ForEach(orderBy =>
        {
            query = ApplyOrderBy(query, orderBy);
        });
        
        return query;
    }
    
    private static IQueryable<TEntity> ApplyInclude<TEntity>(IQueryable<TEntity> query, IncludeSpecification includeSpecification) where TEntity : class
    {
        query = query.Include(includeSpecification.IncludeExpression as Expression<Func<TEntity, object>>);
        return includeSpecification.ThenIncludes.Aggregate(query, (current, include) => ApplyInclude(current, include));
    }

    private static IQueryable<TEntity> ApplyOrderBy<TEntity>(IQueryable<TEntity> query,
        OrderBySpecification orderBySpecification) where TEntity : class
    {
        query = orderBySpecification.Descending
            ? query.OrderByDescending(orderBySpecification.OrderByExpression as Expression<Func<TEntity, object>>)
            : query.OrderBy(orderBySpecification.OrderByExpression as Expression<Func<TEntity, object>>);
        
        return orderBySpecification.ThenBy.Aggregate(query, (current, orderBy) => ApplyOrderBy(current, orderBy));
    }
}