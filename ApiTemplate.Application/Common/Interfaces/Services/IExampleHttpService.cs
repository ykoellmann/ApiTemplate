using ApiTemplate.Domain.GitHub;

namespace ApiTemplate.Application.Common.Interfaces.Services;

public interface IExampleHttpService
{
    Task<ExampleHttp> GetByExampleAsync(string example);
}