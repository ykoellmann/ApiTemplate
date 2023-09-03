using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Common;
using PawPal.Domain.Image.ValueObjects;
using PawPal.Domain.Shelter.Entities;
using PawPal.Domain.Shelter.ValueObjects;
using PawPal.Domain.Species.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class ShelterAdvertisementConfiguration : BaseConfiguration<ShelterAdvertisement, ShelterAdvertisementId>
{
    public override void ConfigureEntity(EntityTypeBuilder<ShelterAdvertisement> builder)
    {
        builder.ToTable("ShelterAdvertisement");
        builder.HasKey(sa => sa.Id);
        builder.Property(sa => sa.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => ShelterAdvertisementId.Create(value));
        builder.Property(sa => sa.ImageSourceId)
            .HasConversion(sourceId => sourceId.Value,
                value => ImageSourceId.Create(value));
            
        builder.Property(sa => sa.Title)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(sa => sa.Name)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(sa => sa.DateOfBirth)
            .HasConversion(
                date => date.ToDateTime(new TimeOnly()),
                value => new DateOnly(value.Year, value.Month, value.Day))
            .IsRequired();
        builder.Property(sa => sa.Description)
            .IsRequired()
            .HasMaxLength(512);
        builder.Property(sa => sa.SpeciesBreedId)
            .HasConversion(sb => sb.Value, 
                value => SpeciesBreedId.Create(value))
            .IsRequired();
        builder.Property(sa => sa.ImageSourceTypeId)
            .HasConversion(ist => ist.Value, 
                value => ImageSourceTypeId.Create(value))
            .IsRequired();
            
        builder.HasOne(sa => sa.SpeciesBreed)
            .WithMany(sb => sb.ShelterAdvertisements)
            .HasForeignKey(sa => sa.SpeciesBreedId);
            
        builder.HasMany(sa => sa.Images)
            .WithOne(i => (ShelterAdvertisement)i.Source)
            .HasForeignKey(i => new { SourceId = i.ImageSourceId, i.ImageSourceTypeId})
            .HasPrincipalKey(sa => new { SourceId = sa.ImageSourceId, sa.ImageSourceTypeId});
            
        builder.HasMany(sa => sa.Chats)
            .WithOne(c => c.ShelterAdvertisement)
            .HasForeignKey(c => c.ShelterAdvertisementId);
            
        builder.HasMany(sa => sa.Likes)
            .WithOne(l => l.ShelterAdvertisement)
            .HasForeignKey(l => l.ShelterAdvertisementId);
    }
}