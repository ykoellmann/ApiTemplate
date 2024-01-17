using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Security.Request;
using ApiTemplate.Infrastructure.Authentication.CurrentUserProvider;
using ApiTemplate.Infrastructure.Authentication.PolicyEnforcer;
using ErrorOr;

namespace ApiTemplate.Infrastructure.Authentication;

public class AuthorizationService : IAuthorizationService
{
    private readonly IPolicyEnforcer _policyEnforcer;
    private readonly ICurrentUserProvider _currentUserProvider;

    public AuthorizationService(IPolicyEnforcer _policyEnforcer,
        ICurrentUserProvider _currentUserProvider)
    {
        this._policyEnforcer = _policyEnforcer;
        this._currentUserProvider = _currentUserProvider;
    }

    public ErrorOr<Success> AuthorizeCurrentUser<T>(
        IAuthorizeableRequest<T> request,
        List<string> requiredRoles,
        List<string> requiredPermissions,
        List<string> requiredPolicies)
    {
        var currentUser = _currentUserProvider.GetCurrentUser();

        if (requiredPermissions.Except(currentUser.Permissions).Any())
        {
            return Error.Unauthorized(description: "User is missing required permissions for taking this action");
        }

        if (requiredRoles.Except(currentUser.Roles).Any())
        {
            return Error.Unauthorized(description: "User is missing required roles for taking this action");
        }

        foreach (var policy in requiredPolicies)
        {
            var authorizationAgainstPolicyResult = _policyEnforcer.Authorize(request, currentUser, policy);

            if (authorizationAgainstPolicyResult.IsError)
            {
                return authorizationAgainstPolicyResult.Errors;
            }
        }

        return Result.Success;
    }
}