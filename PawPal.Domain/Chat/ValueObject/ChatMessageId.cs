using PawPal.Domain.Models;

namespace PawPal.Domain.Chat.ValueObject;

public class ChatMessageId : IdObject<ChatMessageId>
{
    private ChatMessageId(Guid value) : base(value)
    {
    }
}