using FluentValidation;

namespace ApiTemplate.Application.Authentication.Commands.RefreshToken;

internal class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    internal RefreshTokenCommandValidator()
    {
        RuleFor(x => x.UserID)
            .NotEmpty();

        RuleFor(x => x.TokenToRefresh)
            .NotEmpty();
    }
}