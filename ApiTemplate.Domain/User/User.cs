using System.ComponentModel.DataAnnotations.Schema;
using ApiTemplate.Domain.Common;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.User.ValueObjects;

namespace ApiTemplate.Domain.User;

public class User : AggregateRoot<UserId>
{
    // private readonly List<Like.Like> _likes = new();
    
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    // public IReadOnlyList<Like.Like> Likes => _likes.AsReadOnly();
    [NotMapped]
    public override UserId CreatedBy { get; set; }
    [NotMapped]
    public override User CreatedByUser { get; set; }
    [NotMapped]
    public override UserId UpdatedBy { get; set; }
    [NotMapped]
    public override User UpdatedByUser { get; set; }

    private User(UserId id, string firstName, string lastName, string email, string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(UserId.CreateUnique(), firstName, lastName, email, password);
    }
}