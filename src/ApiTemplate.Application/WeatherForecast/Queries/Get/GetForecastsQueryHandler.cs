using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Application.WeatherForecast.Queries.Common;
using ErrorOr;
using MapsterMapper;

namespace ApiTemplate.Application.WeatherForecast.Queries.Get;

public class GetForecastsQueryHandler : IQueryHandler<GetForecastsQuery, List<WeatherForecastResult>>
{
    private readonly IMapper _mapper;
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public GetForecastsQueryHandler(IWeatherForecastRepository weatherForecastRepository, IMapper mapper)
    {
        _weatherForecastRepository = weatherForecastRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<WeatherForecastResult>>> Handle(GetForecastsQuery request, CancellationToken ct)
    {
        var forecasts = await _weatherForecastRepository.GetListAsync(ct);

        return _mapper.Map<List<WeatherForecastResult>>(forecasts);
    }
}