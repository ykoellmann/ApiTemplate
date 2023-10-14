using System.Reflection;
using ApiTemplate.Api.Controllers;
using ApiTemplate.UnitTests.Rules;
using NetArchTest.Rules;

namespace ApiTemplate.Api.UnitTests.Architecture;

public class ArchitectureTests
{
    private readonly Assembly _apiAssembly = typeof(DependencyInjection).Assembly;
    
    [Fact]
    public void AsyncMethods_Should_HaveSuffix_Async()
    {
        var result = Types.InAssembly(_apiAssembly)
            .That()
            .DoNotInherit(typeof(ApiController))
            .Should()
            .MeetCustomRule(new AsyncMethodsHaveSuffixAsyncRule())
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
}