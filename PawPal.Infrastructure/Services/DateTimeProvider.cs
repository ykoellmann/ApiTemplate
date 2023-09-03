using PawPal.Application.Common.Interfaces.Services;

namespace PawPal.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}