using PawPal.Domain.Models;

namespace PawPal.Domain.Preference.ValueObjects;

public class PreferenceSourceTypeId : IdObject<PreferenceSourceTypeId>
{
    private PreferenceSourceTypeId(Guid value) : base(value)
    {
    }
}