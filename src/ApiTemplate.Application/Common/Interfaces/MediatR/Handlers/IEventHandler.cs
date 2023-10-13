using ApiTemplate.Application.Common.Interfaces.MediatR.Requests;
using MediatR;

namespace ApiTemplate.Application.Common.Interfaces.Handlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : INotification
{
    
}