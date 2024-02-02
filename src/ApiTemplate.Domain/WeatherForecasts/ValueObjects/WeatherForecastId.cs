using ApiTemplate.Domain.Models;

namespace ApiTemplate.Domain.WeatherForecasts.ValueObjects;

public class WeatherForecastId : Id<WeatherForecastId>
{
    public WeatherForecastId()
    {
    }
    
    public WeatherForecastId(Guid value) : base(value)
    {
    }
}