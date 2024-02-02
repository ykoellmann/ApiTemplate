namespace ApiTemplate.Api.WeatherForecast.Request;

public record AddForecastRequest(DateTime Date, int TemperatureC, string Summary);