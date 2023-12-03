using Core.Notifications;

namespace Core.OrderRoot;

public class Order : Root, IOrder
{
    private int _id;
    private string _name;
    private DateTime _date;
    protected readonly IList<OrderItem> _items;

    public int Id
    {
        get
        {
            return _id;
        }
        private set
        {
            _id = value;
        }
    }

    public virtual string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new OrderException();
            }

            _name = value;
        }
    }

    public virtual DateTime Date
    {
        get
        {
            return _date;
        }
        set
        {
            if (value < DateTime.Now.Date.AddMonths(-2))
            {
                throw new OrderException();
            }

            _date = value;
        }
    }

    public virtual IReadOnlyList<OrderItem> Items
    {
        get
        {
            return _items.AsReadOnly();
        }
    }

    public Order()
    {
        _name = string.Empty;
        _date = DateTime.MinValue;
        _items = new List<OrderItem>();
    }

    public Order(string name, DateTime date)
    {
        _name = string.Empty;
        _date = DateTime.MinValue;
        _items = new List<OrderItem>();

        Name = name;
        Date = date;
    }

    public virtual void AddItem(string itemName, int quantity, double price)
    {
        var item = new OrderItem(itemName, quantity, price);
        _items.Add(item);
    }

    public virtual void RemoveItem(int itemId)
    {
        if (itemId <= 0)
        {
            throw new OrderException();
        }

        var item = _items.Single(i => i.Id == itemId);
        _items.Remove(item);
    }

    public virtual void UpdateItemName(int itemId, string name)
    {
        var item = _items.Single(i => i.Id == itemId);
        item.Name = name;
    }

    public virtual void UpdateItemQuantity(int itemId, int quantity)
    {
        var item = _items.Single(i => i.Id == itemId);
        item.Quantity = quantity;

        var notification = new UpdateItemQuantityNotification();
        AddNotification(notification);
    }

    public virtual void UpdateItemPrice(int itemId, double price)
    {
        var item = _items.Single(i => i.Id == itemId);
        item.Price = price;
    }

    public virtual void UpdateItemAddress(int itemId, string country, string city)
    {
        var item = _items.Single(item => item.Id == itemId);
        item.Address.Country = country;
        item.Address.City = city;
    }
}