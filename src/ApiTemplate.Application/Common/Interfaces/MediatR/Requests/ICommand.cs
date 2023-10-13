using MediatR;
using ErrorOr;

namespace ApiTemplate.Application.Common.Interfaces.MediatR.Requests;

public interface ICommand<TResult> : IRequest<ErrorOr<TResult>>
{
    
}