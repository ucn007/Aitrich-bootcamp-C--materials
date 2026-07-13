using Bookride.Interfaces;

namespace  Bookride;


public abstract class Ride
{
    public int RideId { get; set; }
    public string CustomerName { get; set; }

    public abstract void CalculateFare();
}

public class BikeRide: Ride, IBookride
{
    public double Distance { get; set; }

    public override void CalculateFare()
    {
        double fare = Distance * 10;
        Console.WriteLine($"Bike Fare: ₹{fare}");
    }

    public void BookRide()
    {
        Console.WriteLine("Bike Ride Booked Successfully");
    }
}
public class CabRide: Ride, IBookride
{
    public double Distance { get; set; }

    public override void CalculateFare()
    {
        double fare = Distance * 100;
        Console.WriteLine($"Cab Fare: ₹{fare}");
    }

    public void BookRide()
    {
        Console.WriteLine("Cab Ride Booked Successfully");
    }
}
public class AutoRide: Ride, IBookride
{
    public double Distance { get; set; }

    public override void CalculateFare()
    {
        double fare = Distance * 30;
        Console.WriteLine($"Auto Fare: ₹{fare}");
    }

    public void BookRide()
    {
        Console.WriteLine("Auto Ride Booked Successfully");
    }
}
public class Program
{
    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Welcome to Bookride!"); 
            Console.WriteLine("1. BikeRide");
            Console.WriteLine("2. CabRide");
            Console.WriteLine("3. AutoRide");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                {
                    BikeRide bike = new BikeRide();

                    Console.Write("Enter Ride Id: ");
                    bike.RideId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Customer Name: ");
                    bike.CustomerName = Console.ReadLine();

                    Console.Write("Enter Distance: ");
                    bike.Distance = Convert.ToDouble(Console.ReadLine());

                    bike.BookRide();
                    bike.CalculateFare();
                    break;
                }
                case 2:
                {
                    CabRide cab = new CabRide();
                    Console.Write("Enter Ride Id: ");
                    cab.RideId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Customer Name: ");
                    cab.CustomerName = Console.ReadLine();
                    Console.Write("Enter Distance: ");
                    cab.Distance = Convert.ToDouble(Console.ReadLine());
                    cab.BookRide();
                    cab.CalculateFare();
                    break;
                    
                }
                
                case 3:
                {
                    AutoRide auto = new AutoRide();
                    Console.Write("Enter Ride Id: ");
                    auto.RideId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Customer Name: ");
                    auto.CustomerName = Console.ReadLine();
                    Console.Write("Enter Distance: ");
                    auto.Distance = Convert.ToDouble(Console.ReadLine());
                    auto.BookRide();
                    auto.CalculateFare();
                    break;
                    
                }
                case 4:
                {
                    exit = true;
                    break;
                }
                default:
                {
                    Console.WriteLine("invalid choice");
                    exit = true;
                    break;
                }
            }
            {
                
            }   
        }
    }
}