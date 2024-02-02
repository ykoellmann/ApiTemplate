using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.WeatherForecasts;
using ApiTemplate.Domain.WeatherForecasts.ValueObjects;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.WeatherForecasts;

public class WeatherForecastRepository : Repository<WeatherForecast, WeatherForecastId>, IWeatherForecastRepository
{
    public WeatherForecastRepository(ApiTemplateDbContext dbContext) : base(dbContext)
    {
    }
}