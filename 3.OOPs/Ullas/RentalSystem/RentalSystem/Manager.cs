namespace RentalSystem;

public class Manager
{
    private Vehicle[] vehicles = new Vehicle[10];
    private Customer[] customers = new Customer[10];

    private int vehicleCount = 0;
    private int customerCount = 0;

    // Add Vehicle
    public void AddVehicle()
    {
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Bike");
        Console.Write("Enter Choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Make: ");
        string make = Console.ReadLine();

        Console.Write("Model: ");
        string model = Console.ReadLine();

        Console.Write("Year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.Write("Registration Number: ");
        string regNo = Console.ReadLine();

        if (choice == 1)
        {
            Console.Write("Number of Seats: ");
            int seats = Convert.ToInt32(Console.ReadLine());

            vehicles[vehicleCount++] =
                new Car(make, model, year, regNo, seats);
        }
        else if (choice == 2)
        {
            Console.Write("Has Carrier (true/false): ");
            bool carrier = Convert.ToBoolean(Console.ReadLine());

            vehicles[vehicleCount++] =
                new Bike(make, model, year, regNo, carrier);
        }

        Console.WriteLine("Vehicle Added Successfully.");
    }

    // List Vehicles
    public void ListVehicles()
    {
        for (int i = 0; i < vehicleCount; i++)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Make : {vehicles[i].Make}");
            Console.WriteLine($"Model: {vehicles[i].Model}");
            Console.WriteLine($"Year : {vehicles[i].Year}");
            Console.WriteLine($"Reg No: {vehicles[i].RegistrationNumber}");
        }
    }

    // Register Customer
    public void RegisterCustomer()
    {
        Console.Write("Customer Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Contact Number: ");
        double contact = Convert.ToDouble(Console.ReadLine());

        Console.Write("Driving Licence Number: ");
        string dl = Console.ReadLine();

        customers[customerCount++] =
            new Customer(id, name, contact, dl);

        Console.WriteLine("Customer Registered.");
    }

    // Display Customers
    public void DisplayCustomers()
    {
        for (int i = 0; i < customerCount; i++)
        {
            Console.WriteLine("------------------------");
            customers[i].DisplayDetails();
        }
    }

    // Rent Vehicle
    public void RentVehicle()
    {
        Console.Write("Enter Customer ID: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        Customer customer = null;

        for (int i = 0; i < customerCount; i++)
        {
            if (customers[i].CustomerId == customerId)
            {
                customer = customers[i];
                break;
            }
        }

        if (customer == null)
        {
            Console.WriteLine("Customer Not Found.");
            return;
        }

        Console.Write("Enter Registration Number: ");
        string regNo = Console.ReadLine();

        Vehicle vehicle = null;

        for (int i = 0; i < vehicleCount; i++)
        {
            if (vehicles[i].RegistrationNumber == regNo)
            {
                vehicle = vehicles[i];
                break;
            }
        }

        if (vehicle == null)
        {
            Console.WriteLine("Vehicle Not Found.");
            return;
        }

        Console.Write("Enter Rental Days: ");
        int days = Convert.ToInt32(Console.ReadLine());

        double rent = vehicle.CalculateRentalCost(days);

        Console.WriteLine();
        Console.WriteLine("===== Rental Summary =====");
        Console.WriteLine($"Customer : {customer.Name}");
        Console.WriteLine($"Vehicle  : {vehicle.Make} {vehicle.Model}");
        Console.WriteLine($"Days     : {days}");
        Console.WriteLine($"Rent     : ${rent}");
    }
}