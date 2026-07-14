using BanckScheme.ManageScheme;
namespace BanckScheme
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            
            ManageScheme.ManageScheme manage = new ManageScheme.ManageScheme();

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("                Bank Scheme Management System");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("1. Add a Banking Scheme");
                Console.WriteLine("2. Register a Customer");
                Console.WriteLine("3. Link Scheme to Customer");
                Console.WriteLine("4. Calculate Interest for a Customer");
                Console.WriteLine("5. Display Customer or Staff Details");
                Console.WriteLine("6. Exit");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.Write("Enter Your Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid Input!");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        manage.AddScheme();
                        break;

                    case 2:
                        manage.RegisterCustomer();
                        break;

                    case 3:
                        manage.LinkScheme();
                        break;

                    case 4:
                        manage.CalculateInterest();
                        break;

                    case 5:
                        manage.DisplayCustomer();
                        break;

                    case 6:
                        exit = true;
                        Console.WriteLine("Thank You for Using Bank Scheme Management System.");
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
}