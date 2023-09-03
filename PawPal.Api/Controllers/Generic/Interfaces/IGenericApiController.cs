using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PawPal.Api.Controllers.Generic.Interfaces;

public interface IGenericApiController<TCreateRequest, TUpdateRequest>
{
    Task<IActionResult> Get();
    
    Task<IActionResult> GetById(Guid id);
    
    Task<IActionResult> Create(
        [FromForm] TCreateRequest request);
    
    Task<IActionResult> Update(Guid id,
        [FromForm] TUpdateRequest request);
    
    Task<IActionResult> Delete(Guid id);
}