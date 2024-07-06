using System.Reflection;
using ApiTemplate.Infrastructure.Persistence.Repositories;
using Mono.Cecil;
using NetArchTest.Rules;

namespace ApiTemplate.UnitTests.Rules;

public class IRepositoryHasRepositoryAndCacheRule : ICustomRule
{
    private readonly Assembly _infrastructureAssembly = typeof(Repository<,>).Assembly;

    public bool MeetsRule(TypeDefinition type)
    {
        var typeReference = type.Resolve()!;
        var interfaceType = Type.GetType(typeReference.FullName + ", " + typeReference.Module.Assembly.FullName);

        var repositories = _infrastructureAssembly
            .GetTypes()
            .Where(type => type.IsClass
                           && !type.IsAbstract
                           && type.GetInterfaces().Contains(interfaceType));

        return repositories.Count() == 2;
    }
}