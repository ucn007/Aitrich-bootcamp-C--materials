using System.Collections.Generic;
using System.Linq;
namespace Tour.Data
{
    public class TourRepository
    {

            private static List<Tour> tours = new List<Tour>();
            private static int nextId = 1;

            public List<Tour> GetAll() => tours;

            public Tour GetById(int id) => tours.FirstOrDefault(t => t.Id == id);

            public void Add(Tour tour)
            {
                tour.Id = nextId++;
                tours.Add(tour);
            }

            public void Update(Tour tour)
            {
                var existing = GetById(tour.Id);
                if (existing != null)
                {
                    existing.Destination = tour.Destination;
                    existing.Price = tour.Price;
                    existing.AvailableSlots = tour.AvailableSlots;
                }
            }

            public void Delete(int id)
            {
                var tour = GetById(id);
                if (tour != null)
                    tours.Remove(tour);
            }
        }
    }


