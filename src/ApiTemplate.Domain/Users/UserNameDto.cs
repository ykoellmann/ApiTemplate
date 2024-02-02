using System.Linq.Expressions;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public class UserNameDto : IDto<UserNameDto, User, UserId>
{
    public UserNameDto(UserId id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public UserId Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public static Expression<Func<User, UserNameDto>> Map() =>
        user => new UserNameDto(user.Id, user.FirstName, user.LastName);
}