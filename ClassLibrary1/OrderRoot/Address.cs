namespace Core.OrderRoot;

public record class Address
{
    private string _country;
    private string _city;

    public string Country
    {
        get
        {
            return _country;
        }
        internal set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new OrderException();
            }

            _country = value;
        }
    }

    public string City
    {
        get
        {
            return _city;
        }
        internal set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new OrderException();
            }

            _city = value;
        }
    }

    public Address()
    {
        _country = string.Empty;
        _city = string.Empty;
    }

    public Address(string country, string city)
    {
        _country = string.Empty;
        _city = string.Empty;

        Country = country;
        City = city;
    }
}