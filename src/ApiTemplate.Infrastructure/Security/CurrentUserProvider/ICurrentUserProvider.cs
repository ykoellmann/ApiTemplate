namespace ApiTemplate.Infrastructure.Authentication.CurrentUserProvider;

public interface ICurrentUserProvider
{
    CurrentUser GetCurrentUser();
}