using System.Text.RegularExpressions;
using MyNamespace.exception;

namespace MyNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a phone number");
                string phoneNumber = Console.ReadLine();
                ValidatePhoneNumber(phoneNumber);
                Console.WriteLine("Phone number is valid.");
            }
            catch (InvalidPhoneException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
           
        }
        
        public static void ValidatePhoneNumber(string phoneNumber)
        {
            // Regular expression pattern for a valid phone number (basic validation)
            string pattern = @"^\+?[1-9]\d{9,14}$"; // Allows international format
            if (!Regex.IsMatch(phoneNumber, pattern))
            {
                throw new InvalidPhoneException("Invalid phone number format.");
            }
        }
    }
};

