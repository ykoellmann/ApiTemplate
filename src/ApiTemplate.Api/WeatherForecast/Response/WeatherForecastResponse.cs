namespace ApiTemplate.Api.WeatherForecast.Response;

public record WeatherForecastResponse(DateTime Date, int TemperatureC, string Summary);