using Core.Common;

namespace WebApplication1.Common;

public class UpdateLocalItemQuantityNotificationHandler : INotificationHandler<UpdateLocalItemQuantityNotification>
{
    public Task Handle(UpdateLocalItemQuantityNotification notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
