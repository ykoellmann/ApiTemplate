using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.WeatherForecasts;
using ApiTemplate.Domain.WeatherForecasts.ValueObjects;
using Microsoft.Extensions.Caching.Distributed;

namespace ApiTemplate.Infrastructure.Persistence.Repositories.WeatherForecasts;

public class CachedWeatherForecastRepository : CachedRepository<WeatherForecast, WeatherForecastId>, IWeatherForecastRepository
{
    public CachedWeatherForecastRepository(
        IRepository<WeatherForecast, WeatherForecastId> decorated, IDistributedCache cache,
        int cacheExpirationMinutes = 10) : base(decorated, cache, cacheExpirationMinutes)
    {
    }

    protected override async IAsyncEnumerable<CacheKey<WeatherForecast>> GetCacheKeysAsync<TChanged>(
        TChanged changedEvent)
    {
        yield break;
    }
}