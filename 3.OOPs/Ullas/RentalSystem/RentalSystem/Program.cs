using RentalSystem;

namespace RentalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n===== Vehicle Rental System =====");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. List Vehicles");
                Console.WriteLine("3. Register Customer");
                Console.WriteLine("4. Rent Vehicle");
                Console.WriteLine("5. Display Customer Details");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        manager.AddVehicle();
                        break;

                    case 2:
                        manager.ListVehicles();
                        break;

                    case 3:
                        manager.RegisterCustomer();
                        break;

                    case 4:
                        manager.RentVehicle();
                        break;

                    case 5:
                        manager.DisplayCustomers();
                        break;

                    case 6:
                        exit = true;
                        Console.WriteLine("Thank you for using the Vehicle Rental System.");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }
    }
}