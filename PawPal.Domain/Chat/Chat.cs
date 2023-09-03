using PawPal.Domain.Chat.Entities;
using PawPal.Domain.Chat.ValueObject;
using PawPal.Domain.Models;
using PawPal.Domain.Shelter.Entities;
using PawPal.Domain.Shelter.ValueObjects;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Domain.Chat;

public class Chat : AggregateRoot<ChatId>
{
    private readonly List<ChatMessage> _chatMessages = new();

    public ShelterAdvertisementId ShelterAdvertisementId { get;  set; }
    public UserId UserId { get;  set; }
    
    public IReadOnlyCollection<ChatMessage> ChatMessages => _chatMessages.AsReadOnly();
    public ShelterAdvertisement ShelterAdvertisement { get; set; } = null!;  
    public User.User User { get; set; } = null!;


    private Chat(ChatId id, ShelterAdvertisementId shelterAdvertisementId, UserId userId) : base(id)
    {
        ShelterAdvertisementId = shelterAdvertisementId;
        UserId = userId;
    }
    
    public static Chat Create(ShelterAdvertisementId shelterAdvertisementId, UserId userId)
    {
        return new(ChatId.CreateUnique(), shelterAdvertisementId, userId);
    }
}