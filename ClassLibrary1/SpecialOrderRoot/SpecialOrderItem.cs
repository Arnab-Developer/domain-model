namespace Core.SpecialOrderRoot;

public class SpecialOrderItem : OrderItem
{
    private string _vendorName;
    private readonly IList<SpecialItemData> _specialItemDatas;

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

    public IReadOnlyList<SpecialItemData> SpecialItemDatas
    {
        get
        {
            return _specialItemDatas.AsReadOnly();
        }
    }

    public SpecialOrderItem(string name, int quantity, double price, string vendorName)
        : base(name, quantity, price)
    {
        _vendorName = string.Empty;
        _specialItemDatas = new List<SpecialItemData>();
        VendorName = vendorName;
    }

    internal void AddSpecialItemData(string name)
    {
        var item = new SpecialItemData(name);
        _specialItemDatas.Add(item);
    }
}