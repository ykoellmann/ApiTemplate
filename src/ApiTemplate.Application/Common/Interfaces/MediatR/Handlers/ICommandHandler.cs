using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using MediatR;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.Handlers;

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, ErrorOr<TResult>> 
    where TCommand : ICommand<TResult>
{
    
}