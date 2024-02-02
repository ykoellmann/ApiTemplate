using ApiTemplate.Domain.Common.Security;

namespace ApiTemplate.Application.Common.Interfaces.Security;

public interface ICurrentUserProvider
{
    CurrentUser GetCurrentUser();
}