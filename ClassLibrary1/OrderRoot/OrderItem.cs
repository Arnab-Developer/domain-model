namespace Core.OrderRoot;

public class OrderItem
{
    private int _id;
    private string _name;
    private int _quantity;
    private double _price;
    private readonly Address _address;

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
        internal set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new OrderException();
            }

            _name = value;
        }
    }

    public virtual int Quantity
    {
        get
        {
            return _quantity;
        }
        internal set
        {
            if (value <= 0)
            {
                throw new OrderException();
            }

            _quantity = value;
        }
    }

    public virtual double Price
    {
        get
        {
            return _price;
        }
        internal set
        {
            if (value <= 0)
            {
                throw new OrderException();
            }

            _price = value;
        }
    }

    public virtual Address Address
    {
        get
        {
            return _address;
        }
    }

    public OrderItem()
    {
        _name = string.Empty;
        _quantity = 0;
        _price = 0;
        _address = new Address();
    }

    public OrderItem(string name, int quantity, double price)
    {
        _name = string.Empty;
        _quantity = 0;
        _price = 0;
        _address = new Address();

        Name = name;
        Quantity = quantity;
        Price = price;
    }
}