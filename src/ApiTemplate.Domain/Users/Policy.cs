using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public class Policy : Entity<PolicyId>
{
    private readonly List<UserPolicy> _userPolicies = new();

    public Policy(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = null!;

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

    public IReadOnlyCollection<UserPolicy> UserPolicies => _userPolicies.AsReadOnly();
}