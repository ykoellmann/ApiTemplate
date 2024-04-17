using ErrorOr;
using MediatR;

namespace ApiTemplate.Application.Common.Interfaces.Security;

public interface IAuthorizationService
{
    ErrorOr<Success> AuthorizeCurrentUser<T>(
        IRequest<T> request,
        List<string> requiredRoles,
        List<string> requiredPermissions,
        List<string> requiredPolicies);
}