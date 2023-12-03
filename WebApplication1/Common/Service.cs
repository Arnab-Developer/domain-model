namespace WebApplication1.Common;

public static class Service
{
    public static void UpdateOrder(IOrder order, int removeItemId, int updateItemId)
    {
        order.Name = "new order";
        order.AddItem("doi", 2, 100.5);
        order.RemoveItem(removeItemId);
        order.UpdateItemAddress(updateItemId, "new country", "new city");
        order.UpdateItemQuantity(updateItemId, 105);
    }
}