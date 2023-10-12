using System.Linq.Expressions;

namespace ApiTemplate.Domain.Common.Specification;

public class OrderBySpecification
{
    public Expression OrderByExpression { get; set; }
    public bool Descending { get; set; }
    public List<OrderBySpecification> ThenBy { get; set; } = new();
}