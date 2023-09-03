using PawPal.Domain.Common;
using PawPal.Domain.Models;

namespace PawPal.Domain.User.ValueObjects;

public class UserId : IdObject<UserId>
{
    private UserId(Guid value) : base(value)
    {
    }
}