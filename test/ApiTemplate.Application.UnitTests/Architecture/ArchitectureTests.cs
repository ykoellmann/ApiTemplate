using System.Reflection;
using ApiTemplate.Application.Common.Events.Created;
using ApiTemplate.Application.Common.Events.Deleted;
using ApiTemplate.Application.Common.Events.Updated;
using ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;
using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using ApiTemplate.UnitTests.Rules;
using FluentValidation;
using MediatR;
using NetArchTest.Rules;

namespace ApiTemplate.Application.UnitTests.Architecture;

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
    
    // [Fact]
    // public void EventHandler_Should_HaveNameEndingWith_EventHandler()
    // {
    //     var result = Types.InAssembly(_applicationAssembly)
    //         .That()
    //         .ImplementInterface(typeof(IEventHandler<>))
    //         .And()
    //         .DoNotHaveNameMatching("`")
    //         .Should()
    //         .HaveNameEndingWith("EventHandler")
    //         .GetResult();
    //     
    //     result.IsSuccessful.Should().BeTrue();
    // }
    
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

    [Fact]
    public void IRepository_Should_HaveImplementedTypes_RepositoryAndCacheRepository()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .That()
            .HaveNameEndingWith("Repository")
            .Should()
            .MeetCustomRule(new IRepositoryHasRepositoryAndCacheRule())
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Validator_Should_HaveNameEndingWith_Validator()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .That()
            .ImplementInterface(typeof(IValidator<>))
            .Should()
            .HaveNameEndingWith("Validator")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void IPipelineBehavior_Should_HaveNameEndingWith_Behaviour()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .That()
            .ImplementInterface(typeof(IPipelineBehavior<,>))
            .Should()
            .HaveNameEndingWith("Behaviour`2")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void AsyncMethods_Should_HaveSuffix_Async()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .That()
            .AreNotInterfaces()
            .And()
            .DoNotImplementInterface(typeof(IRequestHandler<,>))
            .And()
            .DoNotImplementInterface(typeof(IPipelineBehavior<,>))
            .And()
            .DoNotImplementInterface(typeof(IValidator<>))
            .And()
            .DoNotImplementInterface(typeof(INotificationHandler<>))
            .And()
            .DoNotInherit(typeof(CreatedEventHandler<,,,,>))
            .And()
            .DoNotInherit(typeof(UpdatedEventHandler<,,,,>))
            .And()
            .DoNotInherit(typeof(DeletedEventHandler<,,,,>))
            .Should()
            .MeetCustomRule(new AsyncMethodsHaveSuffixAsyncRule())
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
}