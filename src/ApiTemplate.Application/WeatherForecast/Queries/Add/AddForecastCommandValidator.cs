using FluentValidation;

namespace ApiTemplate.Application.WeatherForecast.Queries.Add;

public class AddForecastCommandValidator : AbstractValidator<AddForecastCommand>
{
    public AddForecastCommandValidator()
    {
        RuleFor(x => x.Date)
            .NotEmpty();

        RuleFor(x => x.TemperatureC)
            .InclusiveBetween(-100, 100);

        RuleFor(x => x.Summary)
            .MaximumLength(100)
            .NotEmpty();
    }
}