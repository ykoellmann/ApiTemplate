namespace ApiTemplate.Infrastructure.Settings.Jwt;

public class JwtSettings
{
    public const string SectionName = nameof(JwtSettings);
    public string Secret { get; init; }
    
    public int ExpiryMinutes { get; init; }
    
    public string Issuer { get; init; }
    
    public string Audience { get; init; }
}