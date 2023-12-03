namespace Core.Common;

public abstract class Root : IRoot
{
    private readonly IList<INotification> _notifications;

    public IReadOnlyList<INotification> Notifications
    {
        get
        {
            return _notifications.AsReadOnly();
        }
    }

    public Root()
    {
        _notifications = new List<INotification>();
    }

    public virtual void AddNotification(INotification notification)
    {
        _notifications.Add(notification);
    }

    public void ClearAllNotification()
    {
        _notifications.Clear();
    }
}