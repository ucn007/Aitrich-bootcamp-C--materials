using Exercise.Manager;
using WorkShop.Exception; 
using WorkShop.Models;
using WorkShop.Repository;

namespace Exercise;

public class UserManage
{
    private readonly UserRepository repository;
    private readonly Validation.Validation valid = new();

    private User? loggedUser;

    public UserManage(UserRepository repository)
    {
        this.repository = repository;
    }

    public void AddUser()
    {
        try
        {
            Console.Write("Enter User Id: ");
            int userId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Username: ");
            string username = Console.ReadLine() ?? "";

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine() ?? "";

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine() ?? "";

            Console.Write("Enter Password: ");
            string password = Console.ReadLine() ?? "";

            string email = ReadValidEmail();
            string phone = ReadValidPhone();

            User user = new User(
                userId,
                username,
                password,
                email,
                firstName,
                lastName
            );

            repository.Register(user);

            Console.WriteLine("\nRegistration Successful.");
        }
        catch (UserAlreadyExists.UserAlreadyExistsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input.");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void LoginUser()
    {
        Console.Write("Enter Email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Enter Password: ");
        string password = Console.ReadLine() ?? "";

        User? user = repository.Login(email, password);

        if (user == null)
        {
            Console.WriteLine("Invalid Email or Password.");
            return;
        }

        loggedUser = user;

        Console.WriteLine($"Welcome {user.Username}");

        JobRepository jobRepository = new JobRepository();
        JobManage manager = new JobManage(jobRepository, loggedUser);

        manager.DisplayMenu();
    }

    private string ReadValidEmail()
    {
        while (true)
        {
            Console.Write("Enter Email: ");

            string email = Console.ReadLine() ?? "";

            try
            {
                valid.ValidateEmail(email);
                return email;
            }
            catch (InvalidPattern.InvalidEmailException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private string ReadValidPhone()
    {
        while (true)
        {
            Console.Write("Enter Phone Number: ");

            string phone = Console.ReadLine() ?? "";

            try
            {
                valid.ValidatePhoneNumber(phone);
                return phone;
            }
            catch (InvalidPattern.InvalidPhoneNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}