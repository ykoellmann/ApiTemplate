using PawPal.Domain.Models;
using PawPal.Domain.Preference.ValueObjects;
using PawPal.Domain.Species.Entities;
using PawPal.Domain.Species.ValueObjects;

namespace PawPal.Domain.Species;

public class Species : AggregateRoot<SpeciesId>
{
    private readonly List<SpeciesBreed> _breeds = new();
    private readonly List<Preference.Preference> _preferences = new();

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public IReadOnlyList<SpeciesBreed> Breeds => _breeds.AsReadOnly();
    public IReadOnlyList<Preference.Preference> Preferences => _preferences.AsReadOnly();
    public PreferenceSourceId PreferenceSourceId { get; set; }

    private Species(SpeciesId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
        PreferenceSourceId = PreferenceSourceId.Create(Id.Value);
    }
    
    public static Species Create(string name, string description)
    {
        return new(SpeciesId.CreateUnique(), name, description);
    }
}