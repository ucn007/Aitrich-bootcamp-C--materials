namespace OnlineShop.Exception;

public class InvalidValueException : System.Exception
{
    public InvalidValueException()
        : base("Value is invalid.")
    {
    }

    public InvalidValueException(string message)
        : base(message)
    {
    }
}