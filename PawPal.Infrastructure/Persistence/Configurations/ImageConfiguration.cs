using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Image;
using PawPal.Domain.Image.ValueObjects;
using PawPal.Domain.Shelter.ValueObjects;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class ImageConfiguration : BaseConfiguration<Image, ImageId>
{
    public override void ConfigureEntity(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Image");
        builder.HasKey(i => new { i.Id, i.ImageSourceTypeId});
        
        builder.Property(i => i.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => ImageId.Create(value));

        builder.Property(i => i.FileName)
            .IsRequired()
            .HasMaxLength(512);
        builder.Property(i => i.ContentType)
            .IsRequired()
            .HasConversion<int>();
        builder.Property(i => i.Data)
            .IsRequired();
        builder.Property(i => i.ImageSourceTypeId)
            .IsRequired();
        builder.Property(i => i.ImageSourceId)
            .HasConversion(
                sourceId => sourceId.Value,
                guid => ImageSourceId.Create(guid))
            .IsRequired();
    }
}