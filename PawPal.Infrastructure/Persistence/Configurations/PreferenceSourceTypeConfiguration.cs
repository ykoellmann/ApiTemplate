using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Preference.Entities;
using PawPal.Domain.Preference.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class PreferenceSourceTypeConfiguration : BaseConfiguration<PreferenceSourceType, PreferenceSourceTypeId>
{
    public override void ConfigureEntity(EntityTypeBuilder<PreferenceSourceType> builder)
    {
        builder.ToTable("PreferenceSourceType");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => PreferenceSourceTypeId.Create(value));
        
        builder.Property(pst => pst.Name)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(pst => pst.PreferenceSource)
            .HasConversion<int>();
        
        builder.HasMany(pst => pst.Preferences)
            .WithOne(p => p.PreferenceSourceType)
            .HasForeignKey(p => p.PreferenceSourceTypeId)
            .HasPrincipalKey(pst => pst.Id);
        
        builder.Metadata.FindNavigation(nameof(PreferenceSourceType.Preferences))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}