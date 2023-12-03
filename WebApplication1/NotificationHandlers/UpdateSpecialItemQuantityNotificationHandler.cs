namespace WebApplication1.NotificationHandlers;

public class UpdateSpecialItemQuantityNotificationHandler : INotificationHandler<UpdateSpecialItemQuantityNotification>
{
    public Task Handle(UpdateSpecialItemQuantityNotification notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}