using JobAdmin.Manager;

namespace  JobAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("============================ Job Admin Portal ============================");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.WriteLine("\nEnter Your Choice:");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    {
                        Console.WriteLine("Enter Username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter Password:");
                        string password = Console.ReadLine(); 
                        admin.Register(username, password);
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Enter Username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter Password:");
                        string password = Console.ReadLine(); 
                        admin.Login(username, password);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Exiting......");
                        exit = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid Choice. Please try again.");
                        break;
                    }
                } 
            }
        
            
        }
    }
}