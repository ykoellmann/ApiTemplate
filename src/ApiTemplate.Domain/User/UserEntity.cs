using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.User.ValueObjects;

namespace ApiTemplate.Domain.User;

public class UserEntity : AggregateRoot<UserId>
{
    private UserEntity(UserId id, string firstName, string lastName, string email, string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
    
    //Used for Json serialization
    private UserEntity() : base()
    {
    }
    
    private readonly List<RefreshTokenEntity> _refreshTokens = new();
    
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public IReadOnlyList<RefreshTokenEntity> RefreshTokens => _refreshTokens.AsReadOnly();
    public RefreshTokenEntity? ActiveRefreshToken => _refreshTokens.Find(rt => !rt.Expired);
    [NotMapped]
    public override UserId CreatedBy { get; set; } = null!;

    [NotMapped]
    public override UserEntity CreatedByUserEntity { get; set; } = null!;

    [NotMapped]
    public override UserId UpdatedBy { get; set; } = null!;

    [NotMapped]
    public override UserEntity UpdatedByUserEntity { get; set; } = null!;

    public static UserEntity Create(string firstName, string lastName, string email, string password)
    {
        return new UserEntity(UserId.CreateUnique(), firstName, lastName, email, password);
    }
}