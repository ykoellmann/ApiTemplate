using PawPal.Domain.Common;
using PawPal.Domain.Models;

namespace PawPal.Domain.Shelter.ValueObjects;

public class ShelterId : IdObject<ShelterId>
{
    private ShelterId(Guid value) : base(value)
    {
    }
}