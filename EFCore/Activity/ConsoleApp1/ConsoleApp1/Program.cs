using ConsoleApp1.Service;
using ConsoleApp1.Models;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        TourService tourService = new TourService();
        
       bool exit = false;

       while (!exit)
       {
           Console.WriteLine("Tour Management");
           Console.WriteLine("1. Add Tour");
           Console.WriteLine("2. List Tours");
           Console.WriteLine("3. Delete Tour");
           Console.WriteLine("4. Edit Tour");
           Console.WriteLine("5. Exit");
           
           Console.WriteLine("\nEnter Your Choice:");
           int choice = Convert.ToInt32(Console.ReadLine());

           switch (choice)
           {
               case 1:
               {
                 
                   Console.WriteLine("Enter Tour Name:");
                   string tourName = Console.ReadLine();
                   Console.WriteLine("Enter Tour Description:");
                   string tourDescription = Console.ReadLine();
                   Console.WriteLine("Enter Tour Location:");
                   string tourLocation = Console.ReadLine();
                   Console.WriteLine("Enter Tour Seats:");
                   int seats = Convert.ToInt32(Console.ReadLine());
                   
                   Tours tour = new Tours( tourName, tourDescription, tourLocation, seats);
                   
                   tourService.AddTour(tour);
                   Console.WriteLine("Tour added successfully!");
                   
                   break;
               }

               case 2:
               {
                   List<Tours> tours = tourService.GetTours();

                   foreach (Tours tour in tours)
                   {
                       Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
                       Console.WriteLine(
                           $"ID: {tour.Id} \n" +
                           $"Name: {tour.Name} \n" +
                           $"Location: {tour.Location} \n" +
                           $"Seats: {tour.Seats}\n\n"
                       );
                    
                   }
                   break;
               }
               case 3:
               {
                   Console.WriteLine("Enter Tour ID:");
                   int tourId = Convert.ToInt32(Console.ReadLine());
                   
                  tourService.RemoveTour(tourId);
                   break;
               }
               case 4:
               {
                   Console.WriteLine("Enter Tour ID:");
                   int tourId = Convert.ToInt32(Console.ReadLine());

                   Tours tour = tourService.GetTourById(tourId);

                   if (tour == null)
                   {
                       Console.WriteLine("Tour not found.");
                       break;
                   }

                   tourService.updateTour(tour);

                   Console.WriteLine("Tour updated successfully.");
                   break;
               }
               case 5:
               {
                   exit = true;
                   break;
               }
               default:
               {
                   Console.WriteLine("Invalid Choice");
                   break;
               }
           }
       }
    }
}