using System.Reflection;
using System.Text;
using ApiTemplate.Application.Common.EventHandlers;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Application.Common.Interfaces.Services;
using ApiTemplate.Domain.Common.Events;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
using ApiTemplate.Infrastructure.Attributes;
using ApiTemplate.Infrastructure.Authentication;
using ApiTemplate.Infrastructure.Extensions;
using ApiTemplate.Infrastructure.Persistence;
using ApiTemplate.Infrastructure.Persistence.Interceptors;
using ApiTemplate.Infrastructure.Persistence.Repositories;
using ApiTemplate.Infrastructure.Services;
using ApiTemplate.Infrastructure.Settings;
using ApiTemplate.Infrastructure.Settings.Jwt;
using FluentValidation;
using MediatR;
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
    public static void AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddAuth(configuration);

        services.AddSingleton<IDateTimeService, DateTimeService>();
        services.AddScoped<PublishDomainEventsInterceptor>();

        services.AddDbContext<ApiTemplateDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DbConnection")));

        services.AddRepositories();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
        });
    }

    private static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptionsWithFluentValidation<JwtSettings>(JwtSettings.SectionName);

        services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();

        var jwtSettings = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>();

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
    }

    private static void AddRepositories(this IServiceCollection collection)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        var repositories = assembly
            .GetTypes()
            .Where(x => x.GetInterface(typeof(IRepository<,,>).Name) is not null && x != typeof(Repository<,,>))
            .OrderBy(repo => repo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Any(field => field.FieldType == typeof(IDistributedCache)))
            .ToList();

        repositories.ForEach(repository =>
        {
            var repositoryInterface =
                repository.GetInterfaces().FirstOrDefault(x => x.Name != typeof(IRepository<,,>).Name);

            if (repositoryInterface is null) return;

            if (repository.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Any(field => field.FieldType == typeof(IDistributedCache)))
            {
                collection.Decorate(repositoryInterface, repository);
            }
            else
            {
                collection.AddTransient(repositoryInterface, repository);
                collection.AddCacheEventHandlers(repositoryInterface, repository);
            }
        });
    }

    //ToDo: refactor dont use attributes
    private static void AddCacheEventHandlers(this IServiceCollection collection, Type repositoryInterface,
        Type repository)
    {
        var cacheDomainEvents = repository
            .GetCustomAttributes<CacheDomainEventAttribute>()
            .OrderBy(domainEvent => domainEvent.EventHandlerType == typeof(UpdatedEventHandler<,,,,>) ||
                                    domainEvent.EventHandlerType == typeof(DeletedEventHandler<,,,,>) ||
                                    domainEvent.EventHandlerType == typeof(CreatedEventHandler<,,,,>))
            .ToList();

        var clearedDomainEvents = new List<CacheDomainEventAttribute>();
        foreach (var domainEvent in cacheDomainEvents)
        {
            if (domainEvent.EventHandlerType.BaseType.Name != typeof(UpdatedEventHandler<,,,,>).Name &&
                domainEvent.EventHandlerType.BaseType.Name != typeof(DeletedEventHandler<,,,,>).Name &&
                domainEvent.EventHandlerType.BaseType.Name != typeof(CreatedEventHandler<,,,,>).Name)
            {
                if (clearedDomainEvents.TrueForAll(clearedDomainEvent =>
                        clearedDomainEvent.EventHandlerType.BaseType.Name != domainEvent.EventHandlerType.Name))
                {
                    clearedDomainEvents.Add(domainEvent);
                }
            }
            else
            {
                clearedDomainEvents.Add(domainEvent);
            }
        }


        var genericEventArguments = repository.GetInterface(typeof(IRepository<,,>).Name).GetGenericArguments();

        clearedDomainEvents
            .ForEach(domainEvent =>
            {
                if (domainEvent.EventType.IsGenericType)
                {
                    var arguments = genericEventArguments[Range.EndAt(2)];
                    domainEvent.EventType = domainEvent.EventType.MakeGenericType(arguments);
                }

                if (domainEvent.EventHandlerType.IsGenericType)
                {
                    domainEvent.EventHandlerType = domainEvent.EventHandlerType.MakeGenericType(repositoryInterface,
                        genericEventArguments[0],
                        genericEventArguments[1],
                        genericEventArguments[2],
                        domainEvent.EventType);
                }
            });

        foreach (var domainEvent in clearedDomainEvents)
        {
            var interfaceType = typeof(INotificationHandler<>).MakeGenericType(domainEvent.EventType);
            collection.AddTransient(interfaceType, domainEvent.EventHandlerType);
        }
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