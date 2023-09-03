using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Preference;
using PawPal.Domain.Preference.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class PreferenceConfiguration : BaseConfiguration<Preference, PreferenceId>
{
    public override void ConfigureEntity(EntityTypeBuilder<Preference> builder)
    {
        builder.ToTable("Preference");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => PreferenceId.Create(value));
            
        builder.Property(p => p.UserId)
            .IsRequired();
        builder.Property(p => p.PreferenceSourceId)
            .HasConversion(sourceId => sourceId.Value,
                value => PreferenceSourceId.Create(value))
            .IsRequired();
        builder.Property(p => p.PreferenceSourceTypeId)
            .IsRequired();
    }
}