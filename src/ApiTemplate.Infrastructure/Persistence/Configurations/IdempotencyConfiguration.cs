using ApiTemplate.Domain.Idempotencies;
using ApiTemplate.Domain.Idempotencies.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTemplate.Infrastructure.Persistence.Configurations;

public class IdempotencyConfiguration : BaseConfiguration<Idempotency, IdempotencyId>
{
    public override void Configure(EntityTypeBuilder<Idempotency> builder)
    {
        builder.Property(e => e.Id)
            .HasColumnOrder(0)
            .HasConversion(id => id.Value,
                value => new IdempotencyId(value))
            .IsRequired();
        builder.Property(e => e.CreatedAt)
            .HasColumnOrder(102)
            .IsRequired();
        builder.Property(e => e.UpdatedAt)
            .HasColumnOrder(104)
            .IsRequired();

        ConfigureEntity(builder);
    }
    
    public override void ConfigureEntity(EntityTypeBuilder<Idempotency> builder)
    {
        builder.ToTable("Idempotency");

        builder.HasKey(x => x.Id);

        builder.Property(r => r.RequestName)
            .IsRequired()
            .HasMaxLength(256);
    }
}