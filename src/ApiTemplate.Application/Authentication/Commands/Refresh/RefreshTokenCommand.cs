using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using ApiTemplate.Domain.Users.ValueObjects;

namespace ApiTemplate.Application.Authentication.Commands.Refresh;

public record RefreshTokenCommand(string TokenToRefresh, UserId UserId) : ICommand<AuthenticationResult>;