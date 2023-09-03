using PawPal.Domain.Common;
using PawPal.Domain.Models;

namespace PawPal.Domain.Shelter.ValueObjects;

public class ShelterAdvertisementId : IdObject<ShelterAdvertisementId>
{
    private ShelterAdvertisementId(Guid value) : base(value)
    {
    }
}