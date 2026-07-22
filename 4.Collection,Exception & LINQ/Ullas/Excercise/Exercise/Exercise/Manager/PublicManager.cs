using Exercise.Interface;
using Exercise.Repository;

namespace Exercise.Manager;

public class PublicManager : IMenu
{
    private readonly UserRepository userRepository = new UserRepository();
    private readonly UserManage manager;

    public PublicManager()
    {
        manager = new UserManage(userRepository);
    }

    public void ShowMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("        JOB PORTAL SYSTEM        ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.WriteLine("---------------------------------");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    manager.AddUser();
                    break;

                case "2":
                    manager.LoginUser();
                    break;

                case "3":
                    exit = true;
                    Console.WriteLine("Thank you for using Job Portal.");
                    break;

                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}