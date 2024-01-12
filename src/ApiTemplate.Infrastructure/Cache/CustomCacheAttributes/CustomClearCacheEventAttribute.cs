namespace ApiTemplate.Infrastructure.Cache.CustomCacheAttributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class CustomClearCacheEventAttribute : Attribute
{
    public CustomClearCacheEventAttribute(Type eventType)
    {
        EventType = eventType;
    }

    public Type EventType { get; }
}