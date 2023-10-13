using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using MediatR;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.Handlers;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, ErrorOr<TResult>> 
    where TQuery : IQuery<TResult>
{
    
}