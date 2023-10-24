using ApiTemplate.Api.Common.Http;
using ApiTemplate.Domain.Users.ValueObjects;
using Carter;
using ErrorOr;

namespace ApiTemplate.Api.Controllers;

public abstract class ApiModule : CarterModule
{
    protected ApiModule(string basePath) : base($"/api/{basePath}")
    {
    }
    
    public abstract override void AddRoutes(IEndpointRouteBuilder app);
    
    protected IResult Problem(List<Error> errors, HttpContext httpContext)
    {
        if (!errors.Any())
            return Results.Problem();

        if (errors.TrueForAll(error => error.Type == ErrorType.Validation)) return ValidationProblem(errors);

        httpContext.Items[HttpContextItemKeys.Errors] = errors;

        return Problem(errors.First());
    }

    private IResult Problem(Error error)
    {
        var status = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
        return Results.Problem(statusCode: status, detail: error.Description);
    }

    private IResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new Dictionary<string, string[]>();

        errors.ForEach(error =>
            modelStateDictionary.Add(
                error.Code,
                new[] { error.Description }));

        return Results.ValidationProblem(modelStateDictionary);
    }
    
    protected UserId? UserId(HttpContext httpContext) => httpContext.User?.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value is string guidString
        ? Domain.Users.ValueObjects.UserId.Create(Guid.Parse(guidString))
        : null;
}