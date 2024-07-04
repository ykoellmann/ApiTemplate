using System.Linq.Expressions;
using System.Reflection;
using ApiTemplate.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ApiTemplate.Domain.Common.Specification;

// Mapping of DTO, Include, OrderBy, Tracking, AsNoTracking, AsSplitQuery, IgnoreQueryFilters, 

public abstract class Specification<TEntity, TId, TDto> : SpecificationBase<TEntity, TId>,
    ISpecification<TEntity, TId, TDto>
    where TEntity : Entity<TId>
    where TId : Id<TId>, new()
    where TDto : IDto<TId>
{
    protected abstract Expression<Func<TEntity, TDto>> Map();
    public abstract IQueryable<TDto> Specificate(IQueryable<TEntity> query);
}

public abstract class Specification<TEntity, TId> : SpecificationBase<TEntity, TId>, ISpecification<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>, new()
{
    public abstract IQueryable<TEntity> Specificate(IQueryable<TEntity> query);
}