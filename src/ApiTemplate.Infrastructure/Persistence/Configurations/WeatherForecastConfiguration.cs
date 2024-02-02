using ApiTemplate.Domain.WeatherForecasts;
using ApiTemplate.Domain.WeatherForecasts.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTemplate.Infrastructure.Persistence.Configurations;

public class WeatherForecastConfiguration : BaseConfiguration<WeatherForecast, WeatherForecastId>
{
    public override void ConfigureEntity(EntityTypeBuilder<WeatherForecast> builder)
    {
        builder.ToTable("WeatherForecast");
        
        builder.Property(e => e.Date)
            .IsRequired();
        
        builder.Property(e => e.TemperatureC)
            .IsRequired();

        builder.Property(e => e.Summary)
            .HasMaxLength(100)
            .IsRequired();
    }
}