using ApiTemplate.Application.Common.Interfaces.Services;

namespace ApiTemplate.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}