using PawPal.Domain.Models;

namespace PawPal.Domain.Species.ValueObjects;

public class SpeciesBreedId : IdObject<SpeciesBreedId>
{
    private SpeciesBreedId(Guid value) : base(value)
    {
    }
}