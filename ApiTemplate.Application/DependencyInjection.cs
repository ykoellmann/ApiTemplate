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
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly); });
        
        // services.AddRequestHandlers();

        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), 
        typeof(LoggingBehaviour<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMapping();

        return services;
    }
    
    private static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }

    // private static IServiceCollection AddRequestHandlers(this IServiceCollection collection)
    // {
    //     var assembly = typeof(DependencyInjection).Assembly;
    //
    //     var getRequestTypes = assembly.GetTypes().Where(x => x.GetCustomAttribute<GetRequestHandlerAttribute>() is not null).ToList();
    //
    //     getRequestTypes.ForEach(getRequest =>
    //     {
    //         var attribute = getRequest.GetCustomAttribute<GetRequestHandlerAttribute>();
    //         var resultType = typeof(ErrorOr<>).MakeGenericType(typeof(List<>).MakeGenericType(attribute.Result));
    //         
    //         var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(getRequest, resultType);
    //         var requestHandlerImplementationType = typeof(GetQueryHandler<,,,,>)
    //             .MakeGenericType(getRequest, attribute.Result, attribute.Entity, attribute.Id, attribute.Repository);
    //         
    //         collection.AddTransient(requestHandlerType, requestHandlerImplementationType);
    //     });
    //     
    //     var getByIdRequestTypes = assembly.GetTypes().Where(x => x.GetCustomAttribute<GetByIdRequestHandlerAttribute>() is not null).ToList();
    //     
    //     getByIdRequestTypes.ForEach(getByIdRequest =>
    //     {
    //         var attribute = getByIdRequest.GetCustomAttribute<GetByIdRequestHandlerAttribute>();
    //         var resultType = typeof(ErrorOr<>).MakeGenericType(attribute.Result);
    //         
    //         var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(getByIdRequest, resultType);
    //         var requestHandlerImplementationType = typeof(GetByIdQueryHandler<,,,,>)
    //             .MakeGenericType(getByIdRequest, attribute.Result, attribute.Entity, attribute.Id, attribute.Repository);
    //         
    //         collection.AddTransient(requestHandlerType, requestHandlerImplementationType);
    //     });
    //     
    //     var createRequestTypes = assembly.GetTypes().Where(x => x.GetCustomAttribute<CreateRequestHandlerAttribute>() is not null).ToList();
    //     
    //     createRequestTypes.ForEach(createRequest =>
    //     {
    //         var attribute = createRequest.GetCustomAttribute<CreateRequestHandlerAttribute>();
    //         var resultType = typeof(ErrorOr<>).MakeGenericType(attribute.Result);
    //         
    //         var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(createRequest, resultType);
    //         var requestHandlerImplementationType = typeof(CreateCommandHandler<,,,,>)
    //             .MakeGenericType(createRequest, attribute.Result, attribute.Entity, attribute.Id, attribute.Repository);
    //         
    //         collection.AddTransient(requestHandlerType, requestHandlerImplementationType);
    //     });
    //     
    //     var updateRequestTypes = assembly.GetTypes().Where(x => x.GetCustomAttribute<UpdateRequestHandlerAttribute>() is not null).ToList();
    //     
    //     updateRequestTypes.ForEach(updateRequest =>
    //     {
    //         var attribute = updateRequest.GetCustomAttribute<UpdateRequestHandlerAttribute>();
    //         var resultType = typeof(ErrorOr<>).MakeGenericType(attribute.Result);
    //         
    //         var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(updateRequest, resultType);
    //         var requestHandlerImplementationType = typeof(UpdateCommandHandler<,,,,>)
    //             .MakeGenericType(updateRequest, attribute.Result, attribute.Entity, attribute.Id, attribute.Repository);
    //         
    //         collection.AddTransient(requestHandlerType, requestHandlerImplementationType);
    //     });
    //     
    //     var deleteRequestTypes = assembly.GetTypes().Where(x => x.GetCustomAttribute<DeleteRequestHandlerAttribute>() is not null).ToList();
    //
    //     deleteRequestTypes.ForEach(deleteRequest =>
    //     {
    //         var attribute = deleteRequest.GetCustomAttribute<DeleteRequestHandlerAttribute>();
    //         var resultType = typeof(ErrorOr<>).MakeGenericType(typeof(Deleted));
    //         
    //         var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(deleteRequest, resultType);
    //         var requestHandlerImplementationType = typeof(DeleteCommandHandler<,,,,>)
    //             .MakeGenericType(deleteRequest, attribute.Result, attribute.Entity, attribute.Id, attribute.Repository);
    //         
    //         collection.AddTransient(requestHandlerType, requestHandlerImplementationType);
    //     });
    //     
    //     
    //     return collection;
    // }
}