using ApiTemplate.Application.Common.Security.Request;
using ErrorOr;
using MediatR;

namespace ApiTemplate.Application.Common.Interfaces.Authentication;

public interface IAuthorizationService
{
    ErrorOr<Success> AuthorizeCurrentUser<T>(
        IRequest<T> request,
        List<string> requiredRoles,
        List<string> requiredPermissions,
        List<string> requiredPolicies);
}