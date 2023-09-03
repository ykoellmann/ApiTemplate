using PawPal.Domain.Models;

namespace PawPal.Domain.Preference.ValueObjects;

public class PreferenceId : IdObject<PreferenceId>
{
    private PreferenceId(Guid value) : base(value)
    {
    }
}