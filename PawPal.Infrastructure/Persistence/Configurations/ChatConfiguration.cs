using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Chat;
using PawPal.Domain.Chat.ValueObject;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class ChatConfiguration : BaseConfiguration<Chat, ChatId>
{
    public override void ConfigureEntity(EntityTypeBuilder<Chat> builder)
    {
        builder.ToTable("Chat");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => ChatId.Create(value));

        builder.Property(c => c.ShelterAdvertisementId)
            .IsRequired();
        builder.Property(c => c.UserId)
            .IsRequired();
        
        builder.HasMany(c => c.ChatMessages)
            .WithOne(cm => cm.Chat)
            .HasForeignKey(cm => cm.ChatId)
            .HasPrincipalKey(c => c.Id);
    }
}