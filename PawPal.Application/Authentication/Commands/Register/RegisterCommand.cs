using ErrorOr;
using MediatR;
using PawPal.Application.Authentication.Common;

namespace PawPal.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;