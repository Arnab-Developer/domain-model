namespace Core.Common;

public class UpdateSpecialItemQuantityNotification : INotification
{
    private int _orderId;

    public int OrderId
    {
        get
        {
            return _orderId;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Invalid {nameof(OrderId)}");
            }

            _orderId = value;
        }
    }

    public UpdateSpecialItemQuantityNotification(int orderId)
    {
        _orderId = 0;
        OrderId = orderId;
    }
}