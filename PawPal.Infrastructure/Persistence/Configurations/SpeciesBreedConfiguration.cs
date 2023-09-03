using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Preference.ValueObjects;
using PawPal.Domain.Species.Entities;
using PawPal.Domain.Species.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class SpeciesBreedConfiguration : BaseConfiguration<SpeciesBreed, SpeciesBreedId>
{
    public override void ConfigureEntity(EntityTypeBuilder<SpeciesBreed> builder)
    {
        builder.ToTable("SpeciesBreed");
        builder.HasKey(sb => sb.Id);
        builder.Property(sb => sb.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => SpeciesBreedId.Create(value));
                
        builder.Property(sb => sb.Name)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(sb => sb.Description)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(sb => sb.PreferenceSourceId)
            .HasConversion(sourceId => sourceId.Value,
                value => PreferenceSourceId.Create(value))
            .IsRequired();
                
        builder.HasMany(sb => sb.Preferences)
            .WithOne(p => (SpeciesBreed)p.Source)
            .HasForeignKey(p => p.PreferenceSourceId)
            .HasPrincipalKey(sb => sb.PreferenceSourceId);
    }
}