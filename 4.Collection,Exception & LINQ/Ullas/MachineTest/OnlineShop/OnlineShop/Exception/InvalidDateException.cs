namespace OnlineShop.Exception;

public class InvalidDateException: System.Exception
{
public InvalidDateException()
    : base("Invalid date.")
{
}

public InvalidDateException(string message)
    : base(message)
{
}
}