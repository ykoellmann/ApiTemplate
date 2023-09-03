using BindingFlags = System.Reflection.BindingFlags;

namespace PawPal.Domain.Models;

public class IdObject<TIdObject> : ValueObject
    where TIdObject : IdObject<TIdObject>
{
    protected IdObject(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; set; }

    public static TIdObject CreateUnique()
    {
        return Construct(Guid.NewGuid());
    }

    public static TIdObject Create(Guid value)
    {
        return Construct(value);
    }
    
    private static TIdObject Construct(Guid value)
    {
        var type = typeof(TIdObject);
        
        var constructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] {typeof(Guid)}, null);
        if (constructor is null)
            throw new InvalidOperationException();
        
        return constructor.Invoke(new object[] {value}) as TIdObject ??
               throw new InvalidOperationException();
    }

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
        return Create(value);
    }
}