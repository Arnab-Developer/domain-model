namespace WebApplication1.OrderApis;

public class OrderService : IOrderService
{
    public void UpdateOrder(Order order, int removeItemId, int updateItemId)
    {
        Service.UpdateOrder(order, removeItemId, updateItemId);
    }
}