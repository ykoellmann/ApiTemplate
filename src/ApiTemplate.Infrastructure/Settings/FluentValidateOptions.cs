using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ApiTemplate.Infrastructure.Settings;

public class FluentValidateOptions<TOptions> : IValidateOptions<TOptions> where TOptions : class
{
    private readonly string? _name;
    private readonly IServiceProvider _serviceProvider;

    public FluentValidateOptions(IServiceProvider serviceProvider, string? name)
    {
        _serviceProvider = serviceProvider;
        _name = name;
    }

    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        if (_name is not null && _name != name) return ValidateOptionsResult.Skip;

        ArgumentNullException.ThrowIfNull(options);

        using var scope = _serviceProvider.CreateScope();

        var validator = scope.ServiceProvider.GetService<IValidator<TOptions>>()!;

        var result = validator.Validate(options);
        if (result.IsValid) return ValidateOptionsResult.Success;

        var type = options.GetType().Name;


        var errors = string.Join("\n",
            result.Errors.Select(failure =>
                $"Validation failed for {type}.{failure.PropertyName} with the error: {failure.ErrorMessage}"));

        return ValidateOptionsResult.Fail(errors);
    }
}