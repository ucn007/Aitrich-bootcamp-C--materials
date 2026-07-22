using MyNamespace.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace MyNamespace
{
    internal class EmailValidation
    {
        public void EmailIsValid(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, pattern))
            {
                throw new InvalidEmailException($"Invalid email address: {email}");
            }
        }
    }
}