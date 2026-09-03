using ConsoleApp2.Data;
using ConsoleApp2.Migrations;

namespace ConsoleApp2.Services;

public class TourManage
{
    MyDbContext _context = new MyDbContext();
   

    public void AddTour(Tour tour)
    {
        _context.Tours.Add(tour);
        _context.SaveChanges();
    }
    public Tour GetTour(int id)
    {
        return _context.Tours.Find(id);
    }

    public List<Tour> GetTours()
    {
        return _context.Tours.ToList();
    }

    public void UpdateTour(Tour tour)
    {
        Console.WriteLine("Enter Tour Name ");
        string tourName = Console.ReadLine();
        Console.WriteLine("Enter Tour Description ");
        string tourDescription = Console.ReadLine();
        Console.WriteLine("Enter Tour Location ");
        string tourLocation = Console.ReadLine();
        Console.WriteLine("Enter Tour Seats :");
        int tourSeats = int.Parse(Console.ReadLine());
       
        tour.Name = tourName;
        tour.Description = tourDescription;
        tour.Location = tourLocation;
        tour.Seats = tourSeats;
       
        _context.Tours.Update(tour);
        _context.SaveChanges(); 
        Console.WriteLine("Tour Updated");
    }

    public void DeleteTour(int id)
    {
        var tour = _context.Tours.Find(id);
        _context.Tours.Remove(tour);
        _context.SaveChanges();
    }
}