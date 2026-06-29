

using System;

internal class Program
{
    struct JobProvider
    {
        public string email;
        public string password;
        public int userid;
        public string name;
        public string designation;
        public long phone_no;
    }

    
    static JobProvider[] jobProviders = new JobProvider[10];
    static int userCount = 0;

    private static void Main(string[] args)
    {
        string ch;
        do
        {
            Console.WriteLine("****");
            Console.WriteLine("Welcome to the Hire Me Now Portal!");
            Console.WriteLine("----");
            Console.WriteLine("1. Please login to add or list members");
            Console.WriteLine("****");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Login();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            Console.WriteLine("Do you want to continue? (Y/N)");
            ch = Console.ReadLine();

        } while (ch == "Y" || ch == "y");
    }

    static void Login()
    {
        Console.WriteLine("\nEnter your email: ");
        string email = Console.ReadLine();

        Console.WriteLine("Enter your password: ");
        string password = Console.ReadLine();

        if (email == "new@gmail.com" && password == "new123")
        {
            Console.WriteLine("\nLogin successful!");
            string option;
            do
            {
                Console.WriteLine("\n1. List all company members");
                Console.WriteLine("2. Add company member");
                Console.WriteLine("3. Logout");
                Console.Write("Choose an option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ListMembers();
                        break;

                    case "2":
                        AddMember();
                        break;

                    case "3":
                        Console.WriteLine("Logging out...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again!");
                        break;
                }

            } while (option != "3");
        }
        else
        {
            Console.WriteLine("\nIncorrect email or password. Try again!");
        }
    }

    static void AddMember()
    {
        if (userCount >= jobProviders.Length)
        {
            Console.WriteLine("Cannot add more members. Limit reached!");
            return;
        }

        JobProvider jobProvider = new JobProvider();

        Console.WriteLine("\nEnter User ID: ");
        jobProvider.userid = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Name: ");
        jobProvider.name = Console.ReadLine();

        Console.WriteLine("Enter Designation: ");
        jobProvider.designation = Console.ReadLine();

        Console.WriteLine("Enter Email: ");
        jobProvider.email = Console.ReadLine();

        Console.WriteLine("Enter Phone Number: ");
        jobProvider.phone_no = long.Parse(Console.ReadLine());

        jobProviders[userCount] = jobProvider;
        userCount++;

        Console.WriteLine("\n Member added successfully!");
    }

    static void ListMembers()
    {
        if (userCount == 0)
        {
            Console.WriteLine("\nNo members available yet!");
            return;
        }

        Console.WriteLine("\n********** Company Members **********");
        for (int i = 0; i < userCount; i++)
        {
            Console.WriteLine($"Member ID: {jobProviders[i].userid}");
            Console.WriteLine($"Name: {jobProviders[i].name}");
            Console.WriteLine($"Designation: {jobProviders[i].designation}");
            Console.WriteLine($"Email: {jobProviders[i].email}");
            Console.WriteLine($"Phone Number: {jobProviders[i].phone_no}");
            Console.WriteLine("------------------------------------");
        }
    }
}