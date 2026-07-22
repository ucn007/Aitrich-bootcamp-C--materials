namespace MyNamespace.exception;

internal class InvalidPhoneException: ApplicationException
{
 public  InvalidPhoneException(string message): base(message)
    {
    }
}