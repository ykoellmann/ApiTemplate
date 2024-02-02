using FluentValidation;

namespace ApiTemplate.Application.WeatherForecast.Queries.Get;

public class GetForecastsQueryValidator : AbstractValidator<GetForecastsQuery>
{
    public GetForecastsQueryValidator()
    {
        RuleFor(x => x)
            .NotEmpty();
    }
}