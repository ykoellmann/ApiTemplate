using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Like;
using PawPal.Domain.Like.ValueObjects;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class LikeConfiguration : BaseConfiguration<Like, LikeId>
{
    public override void ConfigureEntity(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable("Like");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => LikeId.Create(value));

        builder.Property(l => l.UserId)
            .IsRequired();
        builder.Property(l => l.ShelterAdvertisementId)
            .IsRequired();
        builder.Property(l => l.IsLiked)
            .IsRequired();
        
        builder.HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId);
        builder.Metadata.FindNavigation(nameof(Like.User))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.HasOne(l => l.ShelterAdvertisement)
            .WithMany(sa => sa.Likes)
            .HasForeignKey(l => l.ShelterAdvertisementId);
        builder.Metadata.FindNavigation(nameof(Like.ShelterAdvertisement))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}