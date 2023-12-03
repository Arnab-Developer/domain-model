namespace Core.LocalOrderRoot;

public class LocalOrderException : OrderException
{
    public LocalOrderException()
        : base("Invalid local order")
    {
    }
}