using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTemplate.Infrastructure.Persistence.Configurations;

public class PermissionConfiguration : BaseConfiguration<Permission, PermissionId>
{
    public override void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.Property(e => e.Id)
            .HasColumnOrder(0)
            .HasConversion(id => id.Value,
                value => new PermissionId(value))
            .IsRequired();
        builder.Property(e => e.CreatedAt)
            .HasColumnOrder(102)
            .IsRequired();
        builder.Property(e => e.UpdatedAt)
            .HasColumnOrder(104)
            .IsRequired();

        ConfigureEntity(builder);
    }

    public override void ConfigureEntity(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permission");

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.Feature, x.Name })
            .IsUnique();

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(128);

        // builder.HasData(typeof(Application.Common.Security.Permission.Permission).GetNestedTypes()
        //     .SelectMany(feature =>
        //         feature.GetFields().Select(field => new Permission(
        //             feature.Name,
        //             field.GetValue(feature).ToString()))));
    }
}