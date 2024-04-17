using ApiTemplate.Domain.Common.Security;
using ErrorOr;
using MediatR;

namespace ApiTemplate.Infrastructure.Security.PolicyEnforcer;

public interface IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IRequest<T> request,
        CurrentUser currentUser,
        string policy);
}