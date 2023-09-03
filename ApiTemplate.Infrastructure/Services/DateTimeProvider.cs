using ApiTemplate.Application.Common.Interfaces.Services;

namespace ApiTemplate.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}