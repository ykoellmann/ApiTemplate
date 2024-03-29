﻿using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Common.Specification;

public abstract class SpecificationOld<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : Id<TId>
{
    public abstract IQueryable<TEntity> Specificate(IQueryable<TEntity> query);
}