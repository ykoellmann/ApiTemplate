using System.Security.Claims;
using ApiTemplate.Application.Common.Interfaces.Security;
using ApiTemplate.Domain.Common.Security;
using ApiTemplate.Domain.Users.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ApiTemplate.Infrastructure.Security.CurrentUserProvider;

public class CurrentUserProvider(IHttpContextAccessor _httpContextAccessor) : ICurrentUserProvider
{
    public CurrentUser GetCurrentUser()
    {
        if (_httpContextAccessor.HttpContext is null) throw new NullReferenceException("HttpContext is null");

        var id = Guid.Parse(GetSingleClaimValue("id"));
        var permissions = GetClaimValues("permissions");
        var roles = GetClaimValues(ClaimTypes.Role);
        var firstName = GetSingleClaimValue(JwtRegisteredClaimNames.Name);
        var lastName = GetSingleClaimValue(ClaimTypes.Surname);
        var email = GetSingleClaimValue(ClaimTypes.Email);

        return new CurrentUser(new UserId(id), firstName, lastName, email, permissions, roles);
    }

    private List<string> GetClaimValues(string claimType)
    {
        return _httpContextAccessor.HttpContext!.User.Claims
            .Where(claim => claim.Type == claimType)
            .Select(claim => claim.Value)
            .ToList();
    }

    private string GetSingleClaimValue(string claimType)
    {
        return _httpContextAccessor.HttpContext!.User.Claims
            .Single(claim => claim.Type == claimType)
            .Value;
    }
}