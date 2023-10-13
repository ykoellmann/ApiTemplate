using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using ErrorOr;
using MediatR;

namespace ApiTemplate.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IQuery<AuthenticationResult>;