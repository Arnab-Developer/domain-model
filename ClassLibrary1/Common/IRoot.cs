namespace Core.Common;

public interface IRoot
{
    public IReadOnlyList<INotification> Notifications { get; }

    public void ClearAllNotification();
}