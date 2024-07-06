using ApiTemplate.Api.WeatherForecast.Request;
using ApiTemplate.Application.WeatherForecast.Queries.Add;
using ApiTemplate.Application.WeatherForecast.Queries.Common;
using Mapster;

namespace ApiTemplate.Api.WeatherForecast;

public class WeatherForecastMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddForecastRequest, AddForecastCommand>()
            .MapToConstructor(true);

        config.NewConfig<Domain.WeatherForecasts.WeatherForecast, WeatherForecastResult>()
            .MapWith(forecast => new WeatherForecastResult(forecast.Date, forecast.TemperatureC, forecast.Summary));
    }
}