using System.Linq.Expressions;
using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Domain.Users;

public interface IUserDto : IDto<UserId> 
{
}