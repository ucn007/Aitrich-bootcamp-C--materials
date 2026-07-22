namespace OnlineShop.Exception;

public class LessthanZeroException: System.Exception
{
    public LessthanZeroException()
        : base("Value is less than zero .")
    {
    }

    public  LessthanZeroException(string message)
        : base(message)
    {
    }
}