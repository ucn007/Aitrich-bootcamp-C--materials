using System;
using MyNamespace;
using MyNamespace.exception;

namespace MyNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter your email address: ");
                string email = Console.ReadLine();

                EmailValidation validation = new EmailValidation();
                validation.EmailIsValid(email);

                Console.WriteLine("Valid Email");
            }
            catch (InvalidEmailException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}