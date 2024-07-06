using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public class UserPolicy : Entity<UserPolicyId>
{
    public UserPolicy(PolicyId policyId, UserId userId)
    {
        PolicyId = policyId;
        UserId = userId;
    }

    public PolicyId PolicyId { get; private set; } = null!;
    public UserId UserId { get; private set; } = null!;

    public User User { get; private set; } = null!;
    public Policy Policy { get; private set; } = null!;

    [NotMapped]
    [Obsolete("Because of generic AggregateRoot")]
    public override UserId CreatedBy { get; set; } = null!;

    [NotMapped]
    [Obsolete("Because of generic AggregateRoot")]
    public override UserId UpdatedBy { get; set; } = null!;


    [NotMapped]
    [Obsolete("Because of generic AggregateRoot")]
    public override User CreatedByUser { get; set; } = null!;

    [NotMapped]
    [Obsolete("Because of generic AggregateRoot")]
    public override User UpdatedByUser { get; set; } = null!;
}