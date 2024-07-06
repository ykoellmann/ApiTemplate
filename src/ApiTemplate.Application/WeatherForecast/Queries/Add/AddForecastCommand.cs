using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using ApiTemplate.Application.Common.Security.Permission;
using ApiTemplate.Application.Common.Security.Request;
using ApiTemplate.Application.WeatherForecast.Queries.Common;

namespace ApiTemplate.Application.WeatherForecast.Queries.Add;

[Authorize(Permissions = Permission.WeatherForecast.Add)]
public record AddForecastCommand(DateTime Date, int TemperatureC, string Summary) : ICommand<WeatherForecastResult>;