namespace Core.SpecialOrderRoot;

public class SpecialOrderException : OrderException
{
    public SpecialOrderException()
        : base("Invalid special order")
    {
    }
}