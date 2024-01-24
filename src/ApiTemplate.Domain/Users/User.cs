using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public class User : AggregateRoot<UserId>
{
    private readonly List<RefreshToken> _refreshTokens = new();
    
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public bool Active { get; set; } = true;
    
    public IReadOnlyList<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();
    public virtual RefreshToken? ActiveRefreshToken => _refreshTokens.SingleOrDefault(rt => !rt.Expired);
    public bool HasActiveRefreshToken => ActiveRefreshToken is not null;
    
    
    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override UserId CreatedBy { get; set; } = null!;

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override UserId UpdatedBy { get; set; } = null!;
    

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override User CreatedByUser { get; set; } = null!;

    [NotMapped, Obsolete("Because of generic AggregateRoot")]
    public override User UpdatedByUser { get; set; } = null!;
    
    public User(string firstName, string lastName, string email, string password) : base(new UserId())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
}