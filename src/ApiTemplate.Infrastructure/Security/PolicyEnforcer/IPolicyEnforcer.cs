using ApiTemplate.Application.Common.Security.Request;
using ApiTemplate.Domain.Common.Security;
using ApiTemplate.Infrastructure.Authentication.CurrentUserProvider;
using ErrorOr;
using MediatR;

namespace ApiTemplate.Infrastructure.Authentication.PolicyEnforcer;

public interface IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IRequest<T> request,
        CurrentUser currentUser,
        string policy);
}