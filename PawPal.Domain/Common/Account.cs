using PawPal.Domain.Models;

namespace PawPal.Domain.Common;

public class Account<TId> : AggregateRoot<TId> 
    where TId : IdObject<TId>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public Account(TId id) : base(id)
    {
    }
}