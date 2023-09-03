using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Image.ValueObjects;
using PawPal.Domain.Shelter;
using PawPal.Domain.Shelter.Entities;
using PawPal.Domain.Shelter.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class ShelterConfiguration : BaseConfiguration<Shelter, ShelterId>
{
    public override void ConfigureEntity(EntityTypeBuilder<Shelter> builder)
    {
        builder.ToTable("Shelter");
        builder.HasKey(x => x.Id);
        builder.Property(s => s.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => ShelterId.Create(value));
        builder.Property(s => s.ImageSourceId)
            .HasConversion(sourceId => sourceId.Value,
                value => ImageSourceId.Create(value));
        
        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(s => s.Password)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(s => s.Address)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(s => s.City)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(s => s.ZipCode)
            .IsRequired()
            .HasMaxLength(5);
        builder.Property(s => s.PhoneNumber)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(s => s.Website)
            .HasMaxLength(256);
        builder.Property(s => s.ImageSourceTypeId)
            .HasConversion(ist => ist.Value,
                value => ImageSourceTypeId.Create(value))
            .IsRequired();

        builder.HasMany(s => s.Images)
            .WithOne(i => (Shelter)i.Source)
            .HasForeignKey(i => new { SourceId = i.ImageSourceId, i.ImageSourceTypeId})
            .HasPrincipalKey(s => new { SourceId = s.ImageSourceId, s.ImageSourceTypeId});
        builder.Metadata.FindNavigation(nameof(Shelter.Images))
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(s => s.Advertisements)
            .WithOne(sa => sa.Shelter)
            .HasForeignKey(sa => sa.ShelterId);
    }
}