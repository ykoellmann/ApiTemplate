using ApiTemplate.Domain.WeatherForecasts;
using ApiTemplate.Domain.WeatherForecasts.ValueObjects;

namespace ApiTemplate.Application.Common.Interfaces.Persistence;

public interface IWeatherForecastRepository : IRepository<Domain.WeatherForecasts.WeatherForecast, WeatherForecastId>
{
    
}