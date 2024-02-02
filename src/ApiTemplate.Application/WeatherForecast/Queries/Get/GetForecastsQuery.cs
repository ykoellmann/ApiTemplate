using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using ApiTemplate.Application.WeatherForecast.Queries.Common;
using MediatR;

namespace ApiTemplate.Application.WeatherForecast.Queries.Get;

public record GetForecastsQuery() : IQuery<List<WeatherForecastResult>>;