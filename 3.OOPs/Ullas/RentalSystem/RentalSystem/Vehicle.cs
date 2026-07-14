namespace RentalSystem;

public class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    private string registrationNumber;

    public string RegistrationNumber
    {
        get { return registrationNumber; }
    }

    public Vehicle(string make, string model, int year, string registrationNumber)
    {
        Make = make;
        Model = model;
        Year = year;
        this.registrationNumber = registrationNumber;
    }

    public virtual double CalculateRentalCost(int days)
    {
        return 0;
    }
}

public class Car: Vehicle
{
    public int NumberOfSeats { get; set; }

    public Car(string make, string model, int year,
        string registrationNumber, int seats)
        : base(make, model, year, registrationNumber)
    {
        NumberOfSeats = seats;
    }

    public override double CalculateRentalCost(int days)
    {
        return days * 50;
    }
}

public class Bike: Vehicle
{
    public bool HasCarrier { get; set; }

    public Bike(string make, string model, int year,
        string registrationNumber, bool carrier)
        : base(make, model, year, registrationNumber)
    {
        HasCarrier = carrier;
    }

    public override double CalculateRentalCost(int days)
    {
        return days * 20;
    }
}