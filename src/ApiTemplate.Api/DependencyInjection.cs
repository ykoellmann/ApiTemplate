using ApiTemplate.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.OpenApi.Models;
using ApiTemplate.Api.Common.Mapping;

namespace ApiTemplate.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        services.AddSingleton<ProblemDetailsFactory, ApiTemplateProblemDetailsFactory>();

        services.AddMapping();

        services.AddRateLimiter(rateLimiterOptions =>
        {
            rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            
            rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
            {
                options.Window = TimeSpan.FromSeconds(10);
                options.PermitLimit = 5;
            });
            
            rateLimiterOptions.AddSlidingWindowLimiter("sliding", options =>
            {
                options.Window = TimeSpan.FromSeconds(15);
                options.SegmentsPerWindow = 3;
                options.PermitLimit = 5;
            });
            
            rateLimiterOptions.AddTokenBucketLimiter("token", options =>
            {
                options.TokenLimit = 100;
                options.ReplenishmentPeriod = TimeSpan.FromSeconds(5);
                options.TokensPerPeriod = 10;
            });

            rateLimiterOptions.AddConcurrencyLimiter("concurrency", options =>
            {
                options.PermitLimit = 5;
            });
        });

        return services;
    }
}