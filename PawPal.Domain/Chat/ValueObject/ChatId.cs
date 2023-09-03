using PawPal.Domain.Models;

namespace PawPal.Domain.Chat.ValueObject;

public class ChatId : IdObject<ChatId>
{
    private ChatId(Guid value) : base(value)
    {
    }
}