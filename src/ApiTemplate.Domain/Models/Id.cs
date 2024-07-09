namespace ApiTemplate.Domain.Models;

public class Id<TIdObject> : ValueObject
    where TIdObject : Id<TIdObject>
{
    public Id(Guid value)
    {
        Value = value;
    }

    public Id()
    {
        Value = Guid.NewGuid();
    }

    public Guid Value { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Guid(Id<TIdObject> id)
    {
        return id.Value;
    }

    public static implicit operator Id<TIdObject>(Guid value)
    {
        return new Id<TIdObject>(value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}