namespace Core.BuyerRoot;

public class Buyer : Root, IBuyer
{
    private int _id;
    private string _name;
    private readonly IList<BuyerDetail> _buyerDetails;

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

    public IReadOnlyList<BuyerDetail> BuyerDetails
    {
        get
        {
            return _buyerDetails.AsReadOnly();
        }
    }

    public Buyer()
    {
        _name = string.Empty;
        _buyerDetails = new List<BuyerDetail>();
    }

    public Buyer(string name)
    {
        _name = string.Empty;
        _buyerDetails = new List<BuyerDetail>();

        Name = name;
    }

    public void AddDetail(string name)
    {
        var buyerDetail = new BuyerDetail(name);
        _buyerDetails.Add(buyerDetail);
    }
}