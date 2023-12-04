namespace Core.BuyerRoot;

public class BuyerDetail
{
    private int _id;
    private string _name;

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

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new BuyerException();
            }

            _name = value;
        }
    }

    public BuyerDetail()
    {
        _name = string.Empty;
    }

    public BuyerDetail(string name)
    {
        _name = string.Empty;
        Name = name;
    }
}