using System.Reflection;
using ApiTemplate.Application.Common.Behaviours;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTemplate.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
            // cfg.RegisterServicesFromAssemblies(typeof(Domain.Common.Events.UpdatedEvent<,>).Assembly);
        });
        
        services.AddPipelineBehaviours();
        
        services.AddMapping();

        return services;
    }
    
    private static void AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
    }
    
    private static void AddPipelineBehaviours(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));

        services.AddScoped(typeof(IPipelineBehavior<,>), 
            typeof(LoggingBehaviour<,>));
    }
}