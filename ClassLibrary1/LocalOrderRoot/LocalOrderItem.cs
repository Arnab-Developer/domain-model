using Core.SpecialOrderRoot;

namespace Core.LocalOrderRoot;

public class LocalOrderItem : OrderItem
{
    private string _vendorName;
    private readonly IList<SpecialItemData> _localItemDatas;

    public string VendorName
    {
        get
        {
            return _vendorName;
        }
        internal set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new OrderException();
            }

            _vendorName = value;
        }
    }

    public IReadOnlyList<SpecialItemData> LocalItemDatas
    {
        get
        {
            return _localItemDatas.AsReadOnly();
        }
    }

    public LocalOrderItem(string name, int quantity, double price, string vendorName)
        : base(name, quantity, price)
    {
        _vendorName = string.Empty;
        _localItemDatas = new List<SpecialItemData>();
        VendorName = vendorName;
    }

    internal void AddSpecialItemData(string name)
    {
        var item = new SpecialItemData(name);
        _localItemDatas.Add(item);
    }
}