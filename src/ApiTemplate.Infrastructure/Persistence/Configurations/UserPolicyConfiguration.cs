using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTemplate.Infrastructure.Persistence.Configurations;

public class UserPolicyConfiguration : BaseConfiguration<UserPolicy, UserPolicyId>
{
    public override void Configure(EntityTypeBuilder<UserPolicy> builder)
    {
        builder.Property(e => e.Id)
            .HasColumnOrder(0)
            .HasConversion(id => id.Value,
                value => new UserPolicyId(value))
            .IsRequired();
        builder.Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValue(DateTime.UtcNow)
            .HasColumnOrder(102)
            .IsRequired();
        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedOnAdd()
            .ValueGeneratedOnUpdate()
            .HasDefaultValue(DateTime.UtcNow)
            .HasColumnOrder(104)
            .IsRequired();

        ConfigureEntity(builder);
    }
    
    public override void ConfigureEntity(EntityTypeBuilder<UserPolicy> builder)
    {
        builder.ToTable("UserPolicy");

        builder.HasKey(up => new { up.Id });
        builder.HasAlternateKey(up => new { up.UserId, up.PolicyId });

        builder.HasOne(up => up.User)
            .WithMany(u => u.UserPolicies)
            .HasForeignKey(up => up.UserId);

        builder.HasOne(up => up.Policy)
            .WithMany(p => p.UserPolicies)
            .HasForeignKey(up => up.PolicyId);
    }
}