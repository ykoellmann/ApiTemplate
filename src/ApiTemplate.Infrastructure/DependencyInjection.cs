using System.Reflection;
using System.Text;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Application.Common.Interfaces.Services;
using ApiTemplate.Infrastructure.Authentication;
using ApiTemplate.Infrastructure.Persistence;
using ApiTemplate.Infrastructure.Persistence.Interceptors;
using ApiTemplate.Infrastructure.Persistence.Repositories;
using ApiTemplate.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ApiTemplate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddAuth(configuration);

        services.AddSingleton<IDateTimeService, DateTimeService>();
        services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddDbContext<ApiTemplateDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
        services.AddRepositories();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
        });

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
            .OrderBy(repo => repo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Any(field => field.FieldType == typeof(IDistributedCache)))
            .ToList();
        
        repositories.ForEach(repository =>
        {
            var repositoryInterface = repository.GetInterfaces().FirstOrDefault(x => x.Name != typeof(IRepository<,>).Name);

            if (repositoryInterface is not null)
            {
                if (repository.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Any(field => field.FieldType == typeof(IDistributedCache)))
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

    private static IServiceCollection AddHttpClient(this IServiceCollection collection)
    {
        collection.AddHttpClient<ExampleHttpService>((provider, client) =>
        {
            client.BaseAddress = new Uri("https://example.com");
            //Add headers, etc.
        });
        collection.AddTransient<IExampleHttpService, ExampleHttpService>();
        
        return collection;
    }
}