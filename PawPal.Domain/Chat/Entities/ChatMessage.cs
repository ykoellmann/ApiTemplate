using PawPal.Domain.Chat.ValueObject;
using PawPal.Domain.Common.Enums;
using PawPal.Domain.Models;

namespace PawPal.Domain.Chat.Entities;

public class ChatMessage : Entity<ChatMessageId>
{
    public ChatId ChatId { get; set; }
    public string Message { get; set; } = null!;
    public Sender Sender { get; set; }
    
    public Chat Chat { get; set; } = null!;
    
    private ChatMessage(ChatMessageId id, ChatId chatId, string message, Sender sender) : base(id)
    {
        ChatId = chatId;
        Message = message;
        Sender = sender;
    }
    
    public static ChatMessage Create(ChatId chatId, string message, Sender sender)
    {
        return new(ChatMessageId.CreateUnique(), chatId, message, sender);
    }
}