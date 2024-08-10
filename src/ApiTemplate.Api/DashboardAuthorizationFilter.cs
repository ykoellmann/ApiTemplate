using Hangfire.Dashboard;

namespace ApiTemplate.Api;

public class DashboardAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        return true;
    }
}