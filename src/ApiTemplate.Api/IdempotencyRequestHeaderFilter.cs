using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiTemplate.Api;

public class IdempotencyRequestHeaderFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter()
        {
            Name = "X-Request-Id",
            In = ParameterLocation.Header,
            Required = false,
            Schema = new OpenApiSchema()
            {
                Type = "Guid",
            }
        });
    }
}