using ErrorOr;
using MediatR;
using PawPal.Application.Authentication.Common;

namespace PawPal.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;