using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.Users.ValueObjects;

public class PolicyId : Id<PolicyId>
{
    public PolicyId()
    {
    }

    public PolicyId(Guid value) : base(value)
    {
    }
}