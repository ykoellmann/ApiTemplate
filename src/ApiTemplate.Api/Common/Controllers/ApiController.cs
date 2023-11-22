using ApiTemplate.Api.Common.Errors;
using ApiTemplate.Domain.Users.ValueObjects;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiTemplate.Api.Common.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    protected UserId? UserId => User?.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value is string guidString
        ? new UserId(Guid.Parse(guidString))
        : null;

    protected IActionResult Problem(List<Error> errors)
    {
        if (!errors.Any())
            return Problem();

        if (errors.TrueForAll(error => error.Type == ErrorType.Validation)) return ValidationProblem(errors);

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return Problem(errors.First());
    }

    private IActionResult Problem(Error error)
    {
        var status = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
        return Problem(statusCode: status, detail: error.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        errors.ForEach(error =>
            modelStateDictionary.AddModelError(
                error.Code,
                error.Description));

        return ValidationProblem(modelStateDictionary);
    }
}