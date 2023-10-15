using MediatR;

namespace ApiTemplate.Application.Common.Interfaces.MediatR.Handlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : INotification
{
    
}