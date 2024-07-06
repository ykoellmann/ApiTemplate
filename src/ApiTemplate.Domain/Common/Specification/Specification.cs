using System.Linq.Expressions;
using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Common.Specification;

// Mapping of DTO, Include, OrderBy, Tracking, AsNoTracking, AsSplitQuery, IgnoreQueryFilters, 

public abstract class Specification<TEntity, TId, TDto> : SpecificationBase<TEntity, TId>,
    ISpecification<TEntity, TId, TDto>
    where TEntity : Entity<TId>
    where TId : Id<TId>, new()
    where TDto : IDto<TId>
{
    public abstract IQueryable<TDto> Specificate(IQueryable<TEntity> query);
    protected abstract Expression<Func<TEntity, TDto>> Map();
}

public abstract class Specification<TEntity, TId> : SpecificationBase<TEntity, TId>, ISpecification<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>, new()
{
    public abstract IQueryable<TEntity> Specificate(IQueryable<TEntity> query);
}