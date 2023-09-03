using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Image.ValueObjects;
using PawPal.Domain.User;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class UserConfiguration : BaseConfiguration<User, UserId>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(e => e.CreatedAt)
            .ValueGeneratedNever()
            .HasColumnOrder(102)
            .IsRequired();
        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedNever()
            .HasColumnOrder(104)
            .IsRequired();
        
       ConfigureEntity(builder);
    }

    public override void ConfigureEntity(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => UserId.Create(value));
        builder.Property(u => u.ImageSourceId)
            .HasConversion(sourceId => sourceId.Value,
                value => ImageSourceId.Create(value));
        
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(u => u.BirthDate)
            .HasConversion(
                date => date.ToDateTime(new TimeOnly()),
                value => new DateOnly(value.Year, value.Month, value.Day))
            .IsRequired();
        builder.Property(u => u.ImageSourceTypeId)
            .HasConversion(ist => ist.Value,
                value => ImageSourceTypeId.Create(value));
        
        
        builder.HasMany(u => u.Images)
            .WithOne(i => (User)i.Source)
            .HasForeignKey(i => new { SourceId = i.ImageSourceId, i.ImageSourceTypeId})
            .HasPrincipalKey(u => new { SourceId = u.ImageSourceId, u.ImageSourceTypeId});
        builder.Metadata.FindNavigation(nameof(User.Images))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.HasMany(u => u.Preferences)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .HasPrincipalKey(u => u.Id);
        builder.Metadata.FindNavigation(nameof(User.Preferences))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.HasMany(u => u.Likes)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId);
        builder.Metadata.FindNavigation(nameof(User.Likes))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.HasMany(u => u.Chats)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .HasPrincipalKey(u => u.Id);
        builder.Metadata.FindNavigation(nameof(User.Chats))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}