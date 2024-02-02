using ApiTemplate.Api.Common.Controllers;
using ApiTemplate.Api.WeatherForecast.Request;
using ApiTemplate.Application.WeatherForecast.Queries.Add;
using ApiTemplate.Application.WeatherForecast.Queries.Get;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Api.WeatherForecast;

public class WeatherForecastController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public WeatherForecastController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetForecasts()
    {
        var result = await _sender.Send(new GetForecastsQuery());

        return result.Match(Ok, Problem);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddForecast([FromBody] AddForecastRequest request)
    {
        var command = _mapper.Map<AddForecastCommand>(request);
        
        var result = await _sender.Send(command);

        return result.Match(Ok, Problem);
    }
}