namespace WebApplication1.SpecialOrderApis;

public class SpecialOrderService : ISpecialOrderService
{
    public void UpdateOrder(SpecialOrder order, int removeItemId, int updateItemId)
    {
        Service.UpdateOrder(order, removeItemId, updateItemId);

        order.SellerName = "new seller name";
        order.UpdateVendorName(updateItemId, "new vendor name");
        order.AddSpecialItemData(updateItemId, "local data");
    }
}