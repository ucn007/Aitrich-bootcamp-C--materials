using System.Text.RegularExpressions;
using WorkShop.Exception;


namespace Exercise.Validation;

public class Validation
{
    public void ValidateEmail(string email)
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        if (!Regex.IsMatch(email, pattern))
        {
            throw new InvalidPattern.InvalidEmailException(
                "Please enter a valid email address."
            );
        }
    }

    public void ValidatePhoneNumber(string phoneNumber)
    {
        string pattern = @"^\+?[1-9]\d{9,14}$";

        if (!Regex.IsMatch(phoneNumber, pattern))
        {
            throw new InvalidPattern.InvalidPhoneNumberException(
                "Please enter a valid phone number."
            );
        }
    }
}