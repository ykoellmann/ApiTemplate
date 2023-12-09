using FluentValidation;

namespace ApiTemplate.Application.Authentication.Commands.Refresh;

internal class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.TokenToRefresh)
            .NotEmpty();
    }
}