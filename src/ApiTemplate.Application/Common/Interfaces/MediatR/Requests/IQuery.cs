using MediatR;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.MediatR.Requests;

public interface IQuery<TResult> : IRequest<ErrorOr<TResult>>
{
    
}