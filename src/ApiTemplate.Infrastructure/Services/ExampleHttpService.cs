using System.Net.Http.Json;
using ApiTemplate.Application.Common.Interfaces.Services;
using ApiTemplate.Domain.GitHub;

namespace ApiTemplate.Infrastructure.Services;

public class ExampleHttpService : IExampleHttpService
{
    private readonly HttpClient _client;

    public ExampleHttpService(HttpClient client)
    {
        _client = client;
    }

    public async Task<ExampleHttp> GetByExampleAsync(string example)
    {
        return await _client.GetFromJsonAsync<ExampleHttp>($"{example}");
    }
}