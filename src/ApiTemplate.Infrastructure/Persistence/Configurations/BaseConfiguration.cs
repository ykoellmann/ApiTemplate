using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTemplate.Infrastructure.Persistence.Configurations;

public abstract class BaseConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity> 
    where TId : Id<TId>, new()
    where TEntity : Entity<TId> 
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.Id)
            .HasColumnOrder(0)
            .HasConversion(id => id.Value,
                value => new TId {Value = value})
            .IsRequired();
        
        builder.Property(e => e.CreatedBy)
            .HasConversion(userId => userId.Value,
                guid => new UserId(guid))
            .HasColumnOrder(101)
            .IsRequired();
        builder.Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValue(DateTime.UtcNow)
            .HasColumnOrder(102)
            .IsRequired();
        builder.Property(e => e.UpdatedBy)
            .HasConversion(userId => userId.Value,
                guid => new UserId(guid))
            .HasColumnOrder(103)
            .IsRequired();
        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedOnUpdate()
            .HasDefaultValue(DateTime.UtcNow)
            .HasColumnOrder(104)
            .IsRequired();
        
        builder.HasOne(e => e.CreatedByUser)
            .WithMany()
            .HasForeignKey(e => e.CreatedBy)
            .HasPrincipalKey(u => u.Id)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(e => e.UpdatedByUser)
            .WithMany()
            .HasForeignKey(e => e.UpdatedBy)
            .HasPrincipalKey(u => u.Id)
            .OnDelete(DeleteBehavior.NoAction);
        
        ConfigureEntity(builder);
    }

    public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
}