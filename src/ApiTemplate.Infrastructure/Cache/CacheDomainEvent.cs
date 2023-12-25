namespace ApiTemplate.Infrastructure.Cache;

public class CacheDomainEvent
{
    public Type EventType { get; set; }
    public Type EventHandlerType { get; set; }

    public CacheDomainEvent(Type eventType, Type eventHandlerType)
    {
        EventType = eventType;
        EventHandlerType = eventHandlerType;
    }
}