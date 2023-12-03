namespace WebApplication1.NotificationHandlers;

public class UpdateLocalItemQuantityNotificationHandler : INotificationHandler<UpdateLocalItemQuantityNotification>
{
    public Task Handle(UpdateLocalItemQuantityNotification notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
