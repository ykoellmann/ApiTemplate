using System.Linq.Expressions;
using System.Reflection;
using ApiTemplate.Domain.Common.Specification;
using ApiTemplate.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ApiTemplate.Infrastructure.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> Specificate<TEntity, TId>(this IQueryable<TEntity> query, Specification<TEntity, TId> specification)
        where TEntity : Entity<TId>
        where TId : IdObject<TId>
    {
        return specification is null ? query : specification.Specificate(query);
    }

    public static IQueryable<TEntity> Specificate<TEntity, TId>(this IQueryable<TEntity> query,
        Func<IQueryable<TEntity>, IQueryable<TEntity>> specification)
        where TEntity : Entity<TId>
        where TId : IdObject<TId>
    {
        return specification is null ? query : specification.Invoke(query);
    }
}