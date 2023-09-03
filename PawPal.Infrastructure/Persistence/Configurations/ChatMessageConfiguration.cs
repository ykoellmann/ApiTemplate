using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPal.Domain.Chat.Entities;
using PawPal.Domain.Chat.ValueObject;

namespace PawPal.Infrastructure.Persistence.Configurations;

public class ChatMessageConfiguration : BaseConfiguration<ChatMessage, ChatMessageId>
{
    public override void ConfigureEntity(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.ToTable("ChatMessage");
        builder.HasKey(x => x.Id);
            
        builder.Property(x => x.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, 
                value => ChatMessageId.Create(value));

        builder.Property(c => c.ChatId)
            .IsRequired();
        builder.Property(c => c.Message)
            .IsRequired()
            .HasMaxLength(512);
        builder.Property(c => c.Sender)
            .IsRequired()
            .HasConversion<int>();
    }
}