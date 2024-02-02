using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.Services;
using ApiTemplate.Domain.Users;
using ApiTemplate.Infrastructure.Settings.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ApiTemplate.Infrastructure.Authentication;

public class JwtTokenProvider : IJwtTokenProvider
{
    private readonly IDateTimeService _dateTimeService;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenProvider(IDateTimeService dateTimeService, IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeService = dateTimeService;
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new("id", user.Id.Value.ToString()),
            new(JwtRegisteredClaimNames.Name, user.FirstName),
            new(ClaimTypes.Surname, user.LastName),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        user.UserPermissions.ToList().ForEach(permission =>
        {
            claims.Add(new Claim("permissions", permission.Permission.Feature));
        });
        user.UserRoles.ToList().ForEach(role =>
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
        });

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var securityToken = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            expires: _dateTimeService.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}