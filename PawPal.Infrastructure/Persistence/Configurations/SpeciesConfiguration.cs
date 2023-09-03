using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Preference.ValueObjects;
using PawPal.Domain.Species;
using PawPal.Domain.Species.Entities;
using PawPal.Domain.Species.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class SpeciesConfiguration : BaseConfiguration<Species, SpeciesId>
{
    public override void ConfigureEntity(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("Species");
        builder.HasKey(x => x.Id);
        builder.Property(s => s.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => SpeciesId.Create(value));
        
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(s => s.Description)
            .IsRequired()
            .HasMaxLength(512);
        builder.Property(s => s.PreferenceSourceId)
            .HasConversion(sourceId => sourceId.Value,
                value => PreferenceSourceId.Create(value))
            .IsRequired();
    
        builder.HasMany(s => s.Breeds)
            .WithOne(b => b.Species)
            .HasForeignKey(b => b.SpeciesId);
        builder.Metadata.FindNavigation(nameof(Species.Breeds))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.HasMany(s => s.Preferences)
            .WithOne(p => (Species)p.Source)
            .HasForeignKey(p => p.PreferenceSourceId)
            .HasPrincipalKey(s => s.PreferenceSourceId);
        builder.Metadata.FindNavigation(nameof(Species.Preferences))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}