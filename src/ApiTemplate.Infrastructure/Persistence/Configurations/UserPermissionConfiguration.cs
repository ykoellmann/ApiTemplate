using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTemplate.Infrastructure.Persistence.Configurations;

public class UserPermissionConfiguration : BaseConfiguration<UserPermission, UserPermissionId>
{
    public override void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.Property(e => e.Id)
            .HasColumnOrder(0)
            .HasConversion(id => id.Value,
                value => new UserPermissionId(value))
            .IsRequired();
        builder.Property(e => e.CreatedAt)
            .HasColumnOrder(102)
            .IsRequired();
        builder.Property(e => e.UpdatedAt)
            .HasColumnOrder(104)
            .IsRequired();

        ConfigureEntity(builder);
    }
    
    public override void ConfigureEntity(EntityTypeBuilder<UserPermission> builder)
    {
        builder.ToTable("UserPermission");

        builder.HasKey(up => new { up.Id });
        builder.HasAlternateKey(up => new { up.UserId, up.PermissionId });

        builder.HasOne(up => up.User)
            .WithMany(u => u.UserPermissions)
            .HasForeignKey(up => up.UserId);

        builder.HasOne(up => up.Permission)
            .WithMany(p => p.UserPermissions)
            .HasForeignKey(up => up.PermissionId);
    }
}