namespace ApiTemplate.Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class CacheDomainEventAttribute : Attribute
{
    public Type EventType { get; set; }
    public Type EventHandlerType { get; set; }

    public CacheDomainEventAttribute(Type eventType, Type eventHandlerType)
    {
        EventType = eventType;
        EventHandlerType = eventHandlerType;
    }
}