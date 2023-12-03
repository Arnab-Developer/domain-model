namespace WebApplication1.LocalOrderApis;

public class LocalOrderService : ILocalOrderService
{
    public void UpdateOrder(LocalOrder order, int removeItemId, int updateItemId)
    {
        Service.UpdateOrder(order, removeItemId, updateItemId);

        order.SellerName = "new seller name";
        order.UpdateVendorName(updateItemId, "new vendor name");
        order.AddSpecialItemData(updateItemId, "local data");
        order.UpdateDataName(updateItemId, 4, "local name 1");
    }
}