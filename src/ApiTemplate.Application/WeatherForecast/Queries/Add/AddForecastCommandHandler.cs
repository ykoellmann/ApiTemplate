using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Application.Common.Interfaces.Security;
using ApiTemplate.Application.WeatherForecast.Queries.Common;
using ErrorOr;

namespace ApiTemplate.Application.WeatherForecast.Queries.Add;

public class AddForecastCommandHandler : ICommandHandler<AddForecastCommand, WeatherForecastResult>
{
    private readonly ICurrentUserProvider _currentUserService;
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public AddForecastCommandHandler(IWeatherForecastRepository weatherForecastRepository,
        ICurrentUserProvider currentUserService)
    {
        _weatherForecastRepository = weatherForecastRepository;
        _currentUserService = currentUserService;
    }

    public async Task<ErrorOr<WeatherForecastResult>> Handle(AddForecastCommand request, CancellationToken ct)
    {
        var weatherForecast =
            new Domain.WeatherForecasts.WeatherForecast(request.Date, request.TemperatureC, request.Summary);

        var user = _currentUserService.GetCurrentUser();

        await _weatherForecastRepository.AddAsync(weatherForecast, user.Id, ct);

        return new WeatherForecastResult(weatherForecast.Date, weatherForecast.TemperatureC, weatherForecast.Summary);
    }
}