using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Image.Entities;
using PawPal.Domain.Image.ValueObjects;
using PawPal.Domain.Shelter.ValueObjects;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class ImageSourceTypeConfiguration : BaseConfiguration<ImageSourceType, ImageSourceTypeId>
{
    public override void ConfigureEntity(EntityTypeBuilder<ImageSourceType> builder)
    {
        builder.ToTable("ImageSourceType");
        builder.HasKey(ist => ist.Id);
            
        builder.Property(ist => ist.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => ImageSourceTypeId.Create(value));
            
        builder.Property(ist => ist.Name)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(ist => ist.ImageSource)
            .HasConversion<int>();

        builder.HasMany(ist => ist.Images)
            .WithOne(i => i.ImageSourceType)
            .HasForeignKey(i => i.ImageSourceTypeId)
            .HasPrincipalKey(ist => ist.Id);
    }
}