using PawPal.Domain.Models;

namespace PawPal.Domain.Preference.ValueObjects;

public class PreferenceSourceId : IdObject<PreferenceSourceId>
{
    protected PreferenceSourceId(Guid value) : base(value)
    {
    }
}