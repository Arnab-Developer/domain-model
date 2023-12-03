namespace Core.OrderRoot;

public class OrderException : Exception
{
    public OrderException()
        : base("Invalid order")
    {
    }

    public OrderException(string message)
        : base(message)
    {
    }
}