using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.WeatherForecasts.ValueObjects;

namespace ApiTemplate.Domain.WeatherForecasts;

public interface IWeatherForecastDto : IDto<WeatherForecastId>
{
    
}