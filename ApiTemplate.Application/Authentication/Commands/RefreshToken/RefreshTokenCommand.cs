using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Domain.User.ValueObjects;
using MediatR;
using ErrorOr;

namespace ApiTemplate.Application.Authentication.Commands.RefreshToken;

public record RefreshTokenCommand(string TokenToRefresh, UserId UserID) : IRequest<ErrorOr<AuthenticationResult>>;