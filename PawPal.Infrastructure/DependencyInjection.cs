using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PawPal.Application.Common.Interfaces.Authentication;
using PawPal.Application.Common.Interfaces.Persistence;
using PawPal.Application.Common.Interfaces.Services;
using PawPal.Infrastructure.Authentication;
using PawPal.Infrastructure.Persistence;
using PawPal.Infrastructure.Persistence.Repositories;
using PawPal.Infrastructure.Persistence.Repositories.User;
using PawPal.Infrastructure.Services;

namespace PawPal.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddAuth(configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddDbContext<PawPalDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
        services.AddRepositories();

        services.AddMemoryCache();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection collection)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        var repositories = assembly
            .GetTypes()
            .Where(x => x.GetInterface(typeof(IRepository<,>).Name) is not null && x != typeof(Repository<,>))
            .OrderBy(repo => repo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Any(field => field.FieldType == typeof(IMemoryCache)))
            .ToList();
        
        repositories.ForEach(repository =>
        {
            var repositoryInterface = repository.GetInterfaces().FirstOrDefault(x => x.Name != typeof(IRepository<,>).Name);

            if (repositoryInterface is not null)
            {
                if (repository.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Any(field => field.FieldType == typeof(IMemoryCache)))
                {
                    collection.Decorate(repositoryInterface, repository);
                }
                else
                {
                    collection.AddTransient(repositoryInterface, repository);
                }
            }
            
        });

        return collection;
    }
}