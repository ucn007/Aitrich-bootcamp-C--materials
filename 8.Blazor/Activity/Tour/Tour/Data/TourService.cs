using System.Collections.Generic;
namespace Tour.Data
{
  
        public class TourService
        {
            private readonly TourRepository _repo = new TourRepository();

            public List<Tour> GetAllTours() => _repo.GetAll();
            public Tour GetTour(int id) => _repo.GetById(id);
            public void AddTour(Tour tour) => _repo.Add(tour);
            public void UpdateTour(Tour tour) => _repo.Update(tour);
            public void DeleteTour(int id) => _repo.Delete(id);
        }
    }

