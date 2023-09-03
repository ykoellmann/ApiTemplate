using PawPal.Domain.Common.Enums;
using PawPal.Domain.Models;
using PawPal.Domain.Preference.Entities;
using PawPal.Domain.Preference.ValueObjects;
using PawPal.Domain.Species.ValueObjects;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Domain.Preference;

public class Preference : AggregateRoot<PreferenceId>
{
    public UserId UserId { get; set; } = null!;
    public PreferenceSourceId PreferenceSourceId { get; set; }
    public PreferenceSourceTypeId PreferenceSourceTypeId { get; set; }
    public bool IsLiked { get; set; }
    
    public User.User User { get; set; } = null!;
    public object Source { get; set; }
    public PreferenceSourceType PreferenceSourceType { get; set; } = null!;

    public Preference(PreferenceId id, UserId userId, PreferenceSourceId preferenceSourceId, PreferenceSourceTypeId preferenceSourceTypeId, bool isLiked) : base(id)
    {
        UserId = userId;
        PreferenceSourceId = preferenceSourceId;
        PreferenceSourceTypeId = preferenceSourceTypeId;
        IsLiked = isLiked;
    }
    
    public static Preference Create(UserId userId, PreferenceSourceId preferenceSourceId, PreferenceSourceTypeId preferenceSourceTypeId, bool isLiked)
    {
        return new(PreferenceId.CreateUnique(), userId, preferenceSourceId, preferenceSourceTypeId, isLiked);
    }
}