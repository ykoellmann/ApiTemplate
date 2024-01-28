using ApiTemplate.Api.Common.Errors;
using ErrorOr;

namespace ApiTemplate.Api.Common.Endpoint;

public class EndpointBase
{
    
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EndpointBase(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected IResult Problem(List<Error> errors)
    {
        if (!errors.Any())
            return Results.Problem();

        if (errors.TrueForAll(error => error.Type == ErrorType.Validation)) return ValidationProblem(errors);

        _httpContextAccessor.HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return Problem(errors.First());
    }

    protected IResult Problem(Error error)
    {
        var status = error.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
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
                [error.Description]));

        return Results.ValidationProblem(modelStateDictionary);
    }
}