using ConsoleApp2.Migrations;
using ConsoleApp2.Services;

namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        TourManage tours = new TourManage();
        
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Create a new tour");
            Console.WriteLine("2. Delete a tour");
            Console.WriteLine("3. Find a tour");
            Console.WriteLine("4. Update tour");
            Console.WriteLine("5. List tours");
            Console.WriteLine("6. Exit");
            
            Console.WriteLine("\nEnter your Choice:");
            int choice = int.Parse(Console.ReadLine());

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
                   
                    Tour tour = new Tour( tourName, tourDescription, tourLocation, seats);
                    tours.AddTour(tour);
                    Console.WriteLine("Tour added successfully!");
                    break;
                }

                case 2:
                {
                    Console.WriteLine("Enter Tour ID:");
                    int tourId = Convert.ToInt32(Console.ReadLine());
                    tours.DeleteTour(tourId);
                    break;
                }

                case 3:
                {
                    Console.WriteLine("Enter Tour ID:");
                    int tourId = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine(tours.GetTour(tourId));
                    
                    break;
                }
                case 4:
                {
                    
                    Console.WriteLine("Enter Tour ID:");
                    int tourId = Convert.ToInt32(Console.ReadLine());

                    Tour tour = tours.GetTour(tourId);

                    if (tour == null)
                    {
                        Console.WriteLine("Tour not found.");
                        break;
                    }

                    tours.UpdateTour(tour);

                    Console.WriteLine("Tour updated successfully.");
                    break;
                }

                case 5:
                {
                    List<Tour> tourLists = tours.GetTours();

                    foreach (Tour tourList in tourLists)
                    {
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine(
                            $"ID: {tourList.Id} \n" +
                            $"Name: {tourList.Name} \n" +
                            $"Location: {tourList.Location} \n" +
                            $"Seats: {tourList.Seats}\n\n"
                        );
                    
                    }
                    break;
                }

                case 6:
                {
                    exit = true;
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid choice!");
                    break;
                }
            }
        }
        
    }
}