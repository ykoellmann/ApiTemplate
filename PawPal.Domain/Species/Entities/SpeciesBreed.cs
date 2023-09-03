using PawPal.Domain.Models;
using PawPal.Domain.Preference.ValueObjects;
using PawPal.Domain.Shelter.Entities;
using PawPal.Domain.Species.ValueObjects;

namespace PawPal.Domain.Species.Entities;

public class SpeciesBreed : Entity<SpeciesBreedId>
{
    private readonly List<Preference.Preference> _preferences = new();
    private readonly List<ShelterAdvertisement> _shelterAdvertisements = new();

    public SpeciesId SpeciesId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IReadOnlyList<Preference.Preference> Preferences => _preferences.AsReadOnly();
    public IReadOnlyList<ShelterAdvertisement> ShelterAdvertisements { get; set; } = null!;
    public Species Species { get; set; } = null!;
    public PreferenceSourceId PreferenceSourceId { get; set; }

    private SpeciesBreed(SpeciesBreedId id, SpeciesId speciesId, string name, string description) : base(id)
    {
        SpeciesId = speciesId;
        Name = name;
        Description = description;
        PreferenceSourceId = PreferenceSourceId.Create(Id.Value);
    }
    
    public static SpeciesBreed Create(SpeciesId speciesId, string name, string description)
    {
        return new(SpeciesBreedId.CreateUnique(), speciesId, name, description);
    }
}