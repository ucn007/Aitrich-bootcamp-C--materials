using BankSystem.Manage;

namespace BankSystem;

class Program
{
    static void Main()
    {
        BankManager manager = new BankManager();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== BANK SYSTEM =====");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Calculate Interest");
            Console.WriteLine("5. Display Account");
            Console.WriteLine("6. Exit");

            Console.Write("Choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    manager.CreateAccount();
                    break;

                case 2:
                    manager.Deposit();
                    break;

                case 3:
                    manager.Withdraw();
                    break;

                case 4:
                    manager.CalculateInterest();
                    break;

                case 5:
                    manager.Display();
                    break;

                case 6:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }
        }
    }
}