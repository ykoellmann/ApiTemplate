using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.WeatherForecasts.ValueObjects;

namespace ApiTemplate.Domain.WeatherForecasts;

public class WeatherForecast : AggregateRoot<WeatherForecastId>
{
    public WeatherForecast(DateTime date, int temperatureC, string summary) : base(new WeatherForecastId())
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    public DateTime Date { get; private set; }

    public int TemperatureC { get; private set; }

    public string Summary { get; private set; }
}