namespace ApiTemplate.Application.Common.Security.Permission;

public static class Permission
{
    public static class WeatherForecast
    {
        public const string Get = $"{nameof(WeatherForecast)}:{nameof(Get)}";
        public const string Add = $"{nameof(WeatherForecast)}:{nameof(Add)}";
    }
}