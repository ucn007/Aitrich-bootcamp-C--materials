using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Data;
namespace ConsoleApp1.Service;

public class TourService
{
    AppDbContext _context = new AppDbContext();
    public void AddTour(Tours tour)
    {
       _context.Tours.Add(tour);
       _context.SaveChanges();
    }
    
    public List<Tours> GetTours()
    {
       var tours = _context.Tours.ToList();
       return tours;
    }

    public Tours GetTourById(int id)
    {
       var tour = _context.Tours.Find(id);
      return  tour;
       
    }

    public void RemoveTour( int id)
    {
       var tour = GetTourById(id);
       _context.Tours.Remove(tour);
       _context.SaveChanges();
    }

    public void updateTour(Tours tour)
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
    }



}