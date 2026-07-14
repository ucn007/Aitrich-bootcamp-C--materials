

using Admin_Job.Manager;
using JobProvider.Enums;
using JobProvider.Exceptions;
using JobProvider.Interface;
using JobProvider.Models;
using JobProvider.Repository;
using System.Text.RegularExpressions;

namespace JobProvider.Manager
{
    public class PublicManager:IMenu
    {
  UserRepository userRepository = new UserRepository();
        public User LoggedUser = new User();
        bool _isLogged = false;
        IMenu menu;
        public void DisplayMenu()
        {
            showUserMenu();
        }
        private void showUserMenu()
        {
            bool exitProgram = false;


            while (!exitProgram)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                string option1 = Console.ReadLine();
                switch (option1)
                {
                    case "1":
                        RegisterProvider();
                        break;
                    case "2":
                        LoginJobProvider();
                        if (_isLogged)
                            menu.DisplayMenu();
                        break;
                       
                    case "3":
                        exitProgram = true;
                        break;
                    default:
                        Console.WriteLine("invalid option ");
                        break;
                }
            }

        }
        void LoginJobProvider()
        {
            try
            {
                //Console.WriteLine("Please enter your email:");
                string email = GetEmail();

                Console.WriteLine("Please enter your password:");
                string password = Console.ReadLine();
                LoggedUser = userRepository.login(email, password);
                if (LoggedUser != null)
                {
                    Console.WriteLine("Login successful!");
                    _isLogged = true;
                    Console.WriteLine("Welcome " + LoggedUser.FirstName);
                    if (LoggedUser.Role == Roles.JobProvider)
                    {
                        menu = new JobManager(LoggedUser);
                    }
                }
                else
                {
                    Console.WriteLine("Login failed. Please try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        void RegisterProvider()
        {
            try
            {
                User newJobSeeker = new User();

                Console.WriteLine("Please enter your first name:");
                newJobSeeker.FirstName = Console.ReadLine();

                Console.WriteLine("Please enter your last name:");
                newJobSeeker.LastName = Console.ReadLine();

                //  Console.WriteLine("Please enter your email address:");
                newJobSeeker.Email = GetEmail();

                newJobSeeker.Phone = GetPhoneNumber();


                Console.WriteLine("Please enter a password:");
                newJobSeeker.Password = Console.ReadLine();
                userRepository.register(newJobSeeker);
                // Register(newJobSeeker);

                Console.WriteLine("Registration successful");
            }
            catch (UserAlreadyExistException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message + "\n"); }
        }


        private string GetEmail()
        {
            try
            {
                Console.WriteLine("Please enter your email address:");
                string email = Console.ReadLine();
                Regex regex = new Regex("^\\S+@\\S+\\.\\S+$");

                if (!regex.IsMatch(email))
                    throw new InvalidFormatException("email was not in correct format :" + email);
                return email;
            }
            catch (InvalidFormatException ex)
            {
                Console.WriteLine(ex.Message + "\n");
                Console.WriteLine("try again...");
                return GetEmail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
                return GetEmail();
            }
        }

        private long GetPhoneNumber()
        {
            try
            {
                Console.WriteLine("Please enter your phone number:");
                long Phone = long.Parse(Console.ReadLine());
                return Phone;
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter valid phone number");
                return GetPhoneNumber();
            }
        }

    }
}
