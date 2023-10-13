using System.Reflection;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using Mono.Cecil;
using NetArchTest.Rules;

namespace ApiTemplate.Infrastructure.UnitTests;

public class ArchitectureTests
{
    private readonly Assembly _infrastructureAssembly = typeof(DependencyInjection).Assembly;
    
    [Fact]
    public void Repository_Should_HaveNameEndingWith_Repository()
    {
        var result = Types.InAssembly(_infrastructureAssembly)
            .That()
            .ImplementInterface(typeof(IRepository<,>))
            .Should()
            .HaveNameEndingWith("Repository")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
}