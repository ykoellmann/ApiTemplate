using System.Reflection;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Infrastructure.Persistence.Configurations;
using ApiTemplate.Infrastructure.Persistence.Repositories;
using ApiTemplate.Infrastructure.UnitTests.Architecture.CustomRules;
using Microsoft.EntityFrameworkCore;
using NetArchTest.Rules;

namespace ApiTemplate.Infrastructure.UnitTests.Architecture;

public class ArchitectureTests
{
    private readonly Assembly _infrastructureAssembly = typeof(DependencyInjection).Assembly;
    
    [Fact]
    public void Repository_Should_HaveNameEndingWith_Repository()
    {
        var result = Types.InAssembly(_infrastructureAssembly)
            .That()
            .ImplementInterface(typeof(IRepository<,>))
            .And()
            .DoNotHaveNameMatching("`")
            .Should()
            .HaveNameEndingWith("Repository")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void CacheRepository_Should_HaveNameStartingWith_Cache()
    {
        var result = Types.InAssembly(_infrastructureAssembly)
            .That()
            .ImplementInterface(typeof(IRepository<,>))
            .And()
            .Inherit(typeof(CachedRepository<,>))
            .Should()
            .HaveNameStartingWith("Cached")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Configuration_Should_InheritFrom_BaseConfiguration()
    {
        var result = Types.InAssembly(_infrastructureAssembly)
            .That()
            .ImplementInterface(typeof(IEntityTypeConfiguration<>))
            .And()
            .DoNotHaveNameMatching("BaseConfiguration")
            .Should()
            .Inherit(typeof(BaseConfiguration<,>))
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Configuration_Should_HaveNameEndingWith_Configuration()
    {
        var result = Types.InAssembly(_infrastructureAssembly)
            .That()
            .Inherit(typeof(BaseConfiguration<,>))
            .Should()
            .HaveNameEndingWith("Configuration")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Extensions_Should_Be_Static()
    {
        var result = Types.InAssembly(_infrastructureAssembly)
            .That()
            .HaveNameEndingWith("Extensions")
            .Should()
            .BeStatic()
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void AsyncMethods_Should_HaveSuffix_Async()
    {
        var result = Types.InAssembly(_infrastructureAssembly)
            .Should()
            .MeetCustomRule(new AsyncMethodsHaveSuffixAsyncRule())
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
}