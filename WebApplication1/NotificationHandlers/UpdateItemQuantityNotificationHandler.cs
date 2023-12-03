namespace WebApplication1.NotificationHandlers;

public class UpdateItemQuantityNotificationHandler : INotificationHandler<UpdateItemQuantityNotification>
{
    public Task Handle(UpdateItemQuantityNotification notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}