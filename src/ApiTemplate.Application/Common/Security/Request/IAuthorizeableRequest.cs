using ApiTemplate.Domain.Users.ValueObjects;
using MediatR;

namespace ApiTemplate.Application.Common.Security.Request;

public interface IAuthorizeableRequest<T> : IRequest<T>
{
    UserId UserId { get; }
}