﻿namespace ApiTemplate.Application.Common.Security.Permission;

public static partial class Permission
{
    public static class WeatherForecast
    {
        public const string Get = $"{nameof(WeatherForecast)}:{nameof(Get)}";
        public const string Set = $"{nameof(WeatherForecast)}:{nameof(Set)}";
    }
}