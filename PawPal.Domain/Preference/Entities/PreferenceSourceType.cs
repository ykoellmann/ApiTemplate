using PawPal.Domain.Common.Enums;
using PawPal.Domain.Models;
using PawPal.Domain.Preference.ValueObjects;

namespace PawPal.Domain.Preference.Entities;

public class PreferenceSourceType : Entity<PreferenceSourceTypeId>
{
    private readonly List<Preference> _preferences = new();

    public string Name { get; set; } = null!;
    public PreferenceSource PreferenceSource { get; set; }
    public IReadOnlyList<Preference> Preferences => _preferences.AsReadOnly();

    private PreferenceSourceType(PreferenceSourceTypeId id, string name, PreferenceSource preferenceSource) : base(id)
    {
        Name = name;
        PreferenceSource = preferenceSource;
    }
    
    public static PreferenceSourceType Create(string name, PreferenceSource preferenceSource)
    {
        return new(PreferenceSourceTypeId.CreateUnique(), name, preferenceSource);
    }
}