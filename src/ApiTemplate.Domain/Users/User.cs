using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public class User : AggregateRoot<UserId>
{
    private readonly List<RefreshToken> _refreshTokens = [];
    private readonly List<UserPermission> _userPermissions = [];
    private readonly List<UserPolicy> _userPolicies = [];
    private readonly List<UserRole> _userRoles = [];

    public User(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }

    public bool Active { get; set; } = true;

    public IReadOnlyList<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();
    public IReadOnlyList<UserRole> UserRoles => _userRoles.AsReadOnly();
    public IReadOnlyList<UserPermission> UserPermissions => _userPermissions.AsReadOnly();
    public IReadOnlyList<UserPolicy> UserPolicies => _userPolicies.AsReadOnly();
    public virtual RefreshToken? ActiveRefreshToken => _refreshTokens.SingleOrDefault(rt => !rt.Expired);
    public bool HasActiveRefreshToken => ActiveRefreshToken is not null;


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