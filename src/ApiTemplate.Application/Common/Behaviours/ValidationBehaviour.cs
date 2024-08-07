﻿using ErrorOr;
using FluentValidation;
using MediatR;

namespace ApiTemplate.Application.Common.Behaviours;

public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehaviour(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken ct)
    {
        if (_validator is null)
            return await next();

        var validationResult = await _validator.ValidateAsync(request, ct);

        if (validationResult.IsValid)
            return await next();

        var errors = validationResult.Errors
            .Select(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage))
            .ToList();

        return (dynamic)errors;
    }
}