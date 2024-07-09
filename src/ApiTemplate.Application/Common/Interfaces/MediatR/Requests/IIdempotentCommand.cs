using ApiTemplate.Domain.Models;

namespace ApiTemplate.Application.Common.Interfaces.MediatR.Requests;

public interface IIdempotentCommand<TResult> : ICommand<TResult>, IIdempotentCommand; 
public interface IIdempotentCommand;