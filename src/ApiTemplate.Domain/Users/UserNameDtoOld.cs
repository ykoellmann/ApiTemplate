using System.Linq.Expressions;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public class UserNameDtoOld : IDtoOld<UserNameDtoOld, User, UserId>
{
    public UserNameDtoOld(UserId id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public UserId Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public static Expression<Func<User, UserNameDtoOld>> Map() =>
        user => new UserNameDtoOld(user.Id, user.FirstName, user.LastName);
}