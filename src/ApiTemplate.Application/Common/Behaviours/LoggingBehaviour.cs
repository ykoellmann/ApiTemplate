using MediatR;
using ErrorOr;
using Serilog;

namespace ApiTemplate.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TResponse : IErrorOr
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger _logger;

    public LoggingBehaviour(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.Information("Request started {@RequestName}, {@DateTimeNow} {@Request}", 
            typeof(TRequest).Name, 
            DateTime.UtcNow, 
            request);
        
        var result = await next();

        if (result.IsError)
        {
            _logger.Error("Request failure {@RequestName}, {@Error}, {@DateTimeNow}", 
                typeof(TRequest).Name, 
                result.Errors,
                DateTime.UtcNow);
        }
        
        _logger.Information("Request finished {@RequestName}, {@DateTimeNow} {@Request}", 
            typeof(TRequest).Name, 
            DateTime.UtcNow, 
            request);
        
        return result;
    }
}