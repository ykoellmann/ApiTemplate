using BindingFlags = System.Reflection.BindingFlags;

namespace ApiTemplate.Domain.Models;

public class IdObject<TIdObject> : ValueObject
    where TIdObject : IdObject<TIdObject>
{
    public IdObject(Guid value)
    {
        Value = value;
    }
    
    
    public IdObject()
    {
        Value = Guid.NewGuid();
    }

    public Guid Value { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Guid(IdObject<TIdObject> idObject)
    {
        return idObject.Value;
    }

    public static implicit operator IdObject<TIdObject>(Guid value)
    {
        return new IdObject<TIdObject>(value);
    }
}