using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using ErrorOr;
using MediatR;

namespace ApiTemplate.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IIdempotentCommand<AuthenticationResult>;