using ApiTemplate.Application.Common.Security.Permission;
using ApiTemplate.Application.Common.Security.Request;

namespace ApiTemplate.Api.WeatherForecast.Response;

public record WeatherForecastResponse(DateTime Date, int TemperatureC, string Summary);