using Core.Notifications;

namespace Core.LocalOrderRoot;

public class LocalOrder : Order
{
    private string _sellerName;

    public string SellerName
    {
        get
        {
            return _sellerName;
        }
        set
        {
            _sellerName = value;
        }
    }

    public LocalOrder(string name, DateTime date, string sellerName)
        : base(name, date)
    {
        _sellerName = string.Empty;
        SellerName = sellerName;
    }

    public override void UpdateItemQuantity(int itemId, int quantity)
    {
        if (quantity < 100)
        {
            throw new LocalOrderException();
        }

        var item = _items.Single(i => i.Id == itemId);
        item.Quantity = quantity;

        var notification = new UpdateLocalItemQuantityNotification();
        AddNotification(notification);
    }

    public override void AddItem(string itemName, int quantity, double price)
    {
        AddItem(itemName, quantity, price, "default vendor");
    }

    public virtual void AddItem(string itemName, int quantity, double price, string vendorName)
    {
        var item = new LocalOrderItem(itemName, quantity, price, vendorName);
        _items.Add(item);
    }

    public virtual void UpdateVendorName(int itemId, string vendorName)
    {
        var item = _items.Single(item => item.Id == itemId);

        if (item is LocalOrderItem spOrderItem)
        {
            spOrderItem.VendorName = vendorName;
        }
    }

    public virtual void AddSpecialItemData(int itemId, string name)
    {
        var item = _items.Single(item => item.Id == itemId);

        if (item is LocalOrderItem spOrderItem)
        {
            spOrderItem.AddSpecialItemData(name);
        }
    }

    public virtual void UpdateDataName(int itemId, int dataId, string name)
    {
        var item = _items.Single(item => item.Id == itemId);

        if (item is LocalOrderItem spOrderItem)
        {
            var data = spOrderItem.LocalItemDatas.Single(d => d.Id == dataId);
            data.Name = name;
        }
    }
}