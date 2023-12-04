namespace Core.BuyerRoot;

public class BuyerException : Exception
{
    public BuyerException()
        : base("Invalid buyer")
    {
    }

    public BuyerException(string message)
        : base(message)
    {
    }
}