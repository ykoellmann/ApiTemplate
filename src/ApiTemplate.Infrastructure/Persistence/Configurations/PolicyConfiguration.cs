using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTemplate.Infrastructure.Persistence.Configurations;

public class PolicyConfiguration : BaseConfiguration<Policy, PolicyId>
{
    public override void Configure(EntityTypeBuilder<Policy> builder)
    {
        builder.Property(e => e.Id)
            .HasColumnOrder(0)
            .HasConversion(id => id.Value,
                value => new PolicyId(value))
            .IsRequired();
        builder.Property(e => e.CreatedAt)
            .HasColumnOrder(102)
            .IsRequired();
        builder.Property(e => e.UpdatedAt)
            .HasColumnOrder(104)
            .IsRequired();

        ConfigureEntity(builder);
    }

    public override void ConfigureEntity(EntityTypeBuilder<Policy> builder)
    {
        builder.ToTable("Policy");

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(128);

        // builder.HasData(typeof(Application.Common.Security.Policies.Policy)
        //     .GetFields()
        //     .Select(x => new Policy(x.Name)));
    }
}