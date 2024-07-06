using ApiTemplate.Application.Common.Security.Policies;
using ApiTemplate.Application.Common.Security.Roles;
using ApiTemplate.Domain.Common.Security;
using ErrorOr;
using MediatR;

namespace ApiTemplate.Infrastructure.Security.PolicyEnforcer;

public class PolicyEnforcer : IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IRequest<T> request,
        CurrentUser currentUser,
        string policy)
    {
        return policy switch
        {
            Policy.SelfOrAdmin => SelfOrAdminPolicy(request, currentUser),
            _ => Error.Unexpected(description: "Unknown policy name")
        };
    }

    private static ErrorOr<Success> SelfOrAdminPolicy<T>(IRequest<T> request, CurrentUser currentUser)
    {
        return currentUser.Roles.Contains(Role.Admin)
            ? Result.Success
            : Error.Unauthorized(description: "Requesting user failed policy requirement");
    }
}