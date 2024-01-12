using MediatR;

namespace ApiTemplate.Application.Users.Events;

public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
{
    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("UserCreatedEvent handled");
    }
}