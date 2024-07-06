using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using ErrorOr;
using MediatR;

namespace ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, ErrorOr<TResult>>
    where TCommand : ICommand<TResult>
{
    new Task<ErrorOr<TResult>> Handle(TCommand request, CancellationToken ct);
}