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
    private const string UserIdClaimType = "id";

    protected UserId? UserId
    {
        get
        {
            var claimValue = User?.Claims.FirstOrDefault(c => c.Type == UserIdClaimType)?.Value;
            if (claimValue != null && Guid.TryParse(claimValue, out var guid)) return new UserId(guid);

            return null;
        }
    }

    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count == 0)
            return Problem();

        if (errors.TrueForAll(error => error.Type == ErrorType.Validation)) return ValidationProblem(errors);

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return Problem(errors.First());
    }

    protected IActionResult Problem(Error error)
    {
        var status = error.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
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