using FluentValidation;

namespace ApiTemplate.Infrastructure.Settings.Jwt;

public sealed class JwtSettingsValidator : AbstractValidator<JwtSettings>
{
    public JwtSettingsValidator()
    {
        RuleFor(x => x.Secret).NotEmpty();
        
        RuleFor(x => x.ExpiryMinutes)
            .NotEmpty()
            .GreaterThan(0);
        
        RuleFor(x => x.Issuer).NotEmpty();
        
        RuleFor(x => x.Audience).NotEmpty();
    }
}