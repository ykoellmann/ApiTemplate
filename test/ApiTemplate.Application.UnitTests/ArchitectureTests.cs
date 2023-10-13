using System.Reflection;
using ApiTemplate.Application.Common.Interfaces.Handlers;
using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using MediatR;
using Mono.Cecil;
using NetArchTest.Rules;

namespace ApiTemplate.Application.UnitTests;

public class ArchitectureTests
{
    private readonly Assembly _applicationAssembly = typeof(DependencyInjection).Assembly;
    
    [Fact]
    public void QueryHandler_Should_HaveNameEndingWith_QueryHandler()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Query_Should_HaveNameEndingWith_Query()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .Should()
            .HaveNameEndingWith("Query")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void CommandHandler_Should_HaveNameEndingWith_CommandHandler()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Command_Should_HaveNameEndingWith_Command()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommand<>))
            .Should()
            .HaveNameEndingWith("Command")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void EventHandler_Should_HaveNameEndingWith_EventHandler()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .That()
            .ImplementInterface(typeof(IEventHandler<>))
            .And()
            .DoNotHaveNameMatching("`")
            .Should()
            .HaveNameEndingWith("EventHandler")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Event_Should_HaveNameEndingWith_Event()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .That()
            .ImplementInterface(typeof(INotification))
            .Should()
            .HaveNameEndingWith("Event")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
}