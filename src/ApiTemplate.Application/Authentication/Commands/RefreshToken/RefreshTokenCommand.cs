using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using ApiTemplate.Domain.Users.ValueObjects;
using MediatR;
using ErrorOr;

namespace ApiTemplate.Application.Authentication.Commands.RefreshToken;

public record RefreshTokenCommand(string TokenToRefresh, UserId UserID) : ICommand<AuthenticationResult>;