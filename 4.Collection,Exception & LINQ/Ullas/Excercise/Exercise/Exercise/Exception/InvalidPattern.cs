namespace Exercise.Exception;

public class InvalidPattern
{
    public class InvalidEmailException: System.Exception
    {
        public InvalidEmailException()
            : base("Invalid email address.")
        {
        }

        public InvalidEmailException(string message)
            : base(message)
        {
        }
    }
    
    public class InvalidPhoneNumberException: System.Exception
    {
        public InvalidPhoneNumberException()
            : base("Invalid phone number.")
        {
        }

        public InvalidPhoneNumberException(string message)
            : base(message)
        {
        }
    }
}