namespace WorkShop.Exception;

public class UserAlreadyExists
{
    public class UserAlreadyExistsException: System.Exception
    {
        // Default constructor
        public UserAlreadyExistsException()
            : base("User already exists.")
        {
        }

        // Constructor with custom message
        public UserAlreadyExistsException(string message)
            : base(message)
        {
        }

        // Constructor with inner exception
        public UserAlreadyExistsException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}