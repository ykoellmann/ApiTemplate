using PawPal.Domain.Models;

namespace PawPal.Domain.Species.ValueObjects;

public class SpeciesId : IdObject<SpeciesId>
{
    private SpeciesId(Guid value) : base(value)
    {
    }
}