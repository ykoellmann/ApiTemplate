using ErrorOr;
using MediatR;

namespace ApiTemplate.Application.Common.Interfaces.MediatR.Requests;

public interface IQuery<TResult> : IRequest<ErrorOr<TResult>>;