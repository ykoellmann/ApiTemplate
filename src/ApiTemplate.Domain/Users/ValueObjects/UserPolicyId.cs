using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class UserPolicyId : Id<UserPolicyId>
{
    public UserPolicyId()
    {
    }

    public UserPolicyId(Guid value) : base(value)
    {
    }
}