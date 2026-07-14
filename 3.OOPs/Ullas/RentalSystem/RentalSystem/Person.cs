namespace RentalSystem;

public abstract class Person
{
    public string Name { get; set; }
    public double ContactNumber { get; set; }

    protected Person(string name, double contact)
    {
        Name = name;
        ContactNumber = contact;
    }

    public abstract void DisplayDetails();
}

public class Customer: Person
{
    public int CustomerId { get; set; }

    private string drivingLicenseNumber;

    public string DrivingLicenseNumber
    {
        get { return drivingLicenseNumber; }
    }

    public Customer(int id, string name, double contact, string dl)
        : base(name, contact)
    {
        CustomerId = id;
        drivingLicenseNumber = dl;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Customer ID : {CustomerId}");
        Console.WriteLine($"Name        : {Name}");
        Console.WriteLine($"Contact     : {ContactNumber}");
        Console.WriteLine($"DL Number   : {DrivingLicenseNumber}");
    }
}

public class Employee: Person
{
    public int EmployeeId { get; set; }
    public string Position { get; set; }

    public Employee(int id, string name,
        double contact, string position)
        : base(name, contact)
    {
        EmployeeId = id;
        Position = position;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Employee ID : {EmployeeId}");
        Console.WriteLine($"Name        : {Name}");
        Console.WriteLine($"Position    : {Position}");
    }
}