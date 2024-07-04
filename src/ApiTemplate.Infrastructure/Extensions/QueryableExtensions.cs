using System.Linq.Expressions;
using System.Reflection;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ApiTemplate.Infrastructure.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> Specificate<TEntity, TId>(this IQueryable<TEntity> query, ISpecification<TEntity, TId>? specification = null)
        where TEntity : Entity<TId>
        where TId : Id<TId>, new()
    {
        return specification is null ? query : specification.Specificate(query);
    }
    
    public static IQueryable<TDto> Specificate<TEntity, TId, TDto>(this IQueryable<TEntity> query, ISpecification<TEntity, TId, TDto> specification)
        where TEntity : Entity<TId>
        where TId : Id<TId>, new()
    {
        return specification.Specificate(query);
    }
}