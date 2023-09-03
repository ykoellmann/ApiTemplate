using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PawPal.Api.Controllers.Generic.Interfaces;

namespace PawPal.Api.Controllers.Generic;

[Route("api/[controller]")]
public class GenericApiController<
    TGetQuery,
    TGetByIdQuery, 
    TCreateRequest, TCreateCommand, 
    TUpdateRequest, TUpdateCommand, 
    TDeleteCommand,
    TResult,
    TResponse> 
    : ApiController,
        IGenericApiController<TCreateRequest, TUpdateRequest>
    where TGetQuery : IRequest<ErrorOr<List<TResult>>>, new()
    where TGetByIdQuery : IRequest<ErrorOr<TResult>>
    where TCreateCommand : IRequest<ErrorOr<TResult>>
    where TUpdateCommand : IRequest<ErrorOr<TResult>>
    where TDeleteCommand : IRequest<ErrorOr<Deleted>>, new()
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public GenericApiController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new TGetQuery();

        var result = await _mediator.Send(query);

        return result.Match(
            result => Ok(_mapper.Map<TResponse>(result)),
            errors => Problem(errors));
    }
    
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = (TGetByIdQuery)Activator.CreateInstance(typeof(TGetByIdQuery), id);

        var authResult = await _mediator.Send(query);

        return authResult.Match(
            authResult => Ok(_mapper.Map<TResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost]
    public async Task<IActionResult> Create(TCreateRequest request)
    {
        var command = _mapper.Map<TCreateCommand>(request);

        var result = await _mediator.Send(command);

        var tmp = Guid.NewGuid();

        return result.Match(
            result => CreatedAtAction(nameof(GetById), new { id = tmp }, _mapper.Map<TResponse>(result)),
            errors => Problem(errors));
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, TUpdateRequest request)
    {
        var command = _mapper.Map<TUpdateCommand>(request);

        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<TResponse>(result)),
            errors => Problem(errors));
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = (TDeleteCommand)Activator.CreateInstance(typeof(TDeleteCommand), id);

        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            errors => Problem(errors));
    }
}