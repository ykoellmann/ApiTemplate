using ApiTemplate.Application.Common.Security.Request;
using ApiTemplate.Infrastructure.Authentication.CurrentUserProvider;
using ErrorOr;

namespace ApiTemplate.Infrastructure.Authentication.PolicyEnforcer;

public interface IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IAuthorizeableRequest<T> request,
        CurrentUser currentUser,
        string policy);
}