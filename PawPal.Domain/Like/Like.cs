using PawPal.Domain.Like.ValueObjects;
using PawPal.Domain.Models;
using PawPal.Domain.Shelter.Entities;
using PawPal.Domain.Shelter.ValueObjects;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Domain.Like;

public class Like : AggregateRoot<LikeId>
{
    public UserId UserId { get; set; } = null!;
    public ShelterAdvertisementId ShelterAdvertisementId { get; set; } = null!;
    public bool IsLiked { get; set; }
    
    public User.User User { get; set; } = null!;
    public ShelterAdvertisement ShelterAdvertisement { get; set; } = null!;

    private Like(LikeId id, UserId userId, ShelterAdvertisementId shelterAdvertisementId, bool isLiked) : base(id)
    {
        UserId = userId;
        ShelterAdvertisementId = shelterAdvertisementId;
        IsLiked = isLiked;
    }
    
    public static Like Create(UserId userId, ShelterAdvertisementId shelterAdvertisementId, bool isLiked)
    {
        return new(LikeId.CreateUnique(), userId, shelterAdvertisementId, isLiked);
    }
}