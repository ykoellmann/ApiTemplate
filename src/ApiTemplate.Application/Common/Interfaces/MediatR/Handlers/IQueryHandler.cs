using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using ErrorOr;
using MediatR;

namespace ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, ErrorOr<TResult>>
    where TQuery : IQuery<TResult>
{
    new Task<ErrorOr<TResult>> Handle(TQuery request, CancellationToken ct);
}