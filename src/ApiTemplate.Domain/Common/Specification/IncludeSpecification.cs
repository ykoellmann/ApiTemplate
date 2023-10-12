using System.Linq.Expressions;

namespace ApiTemplate.Domain.Common.Specification;

public class IncludeSpecification
{
    public Expression IncludeExpression { get; set; }
    public List<IncludeSpecification> ThenIncludes { get; } = new();
}