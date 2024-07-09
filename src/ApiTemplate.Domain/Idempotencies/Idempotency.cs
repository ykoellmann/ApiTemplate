using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.Idempotencies.ValueObjects;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Idempotencies;

public class Idempotency : Entity<IdempotencyId>
{
    public Idempotency(IdempotencyId id, string requestName)
    {
        Id = id;
        RequestName = requestName;
    }

    public string RequestName { get; set; }
    
    
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