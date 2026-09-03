using TourManageDb.Data;
using TourManageDb.Model;

namespace TourManageDb.Interface
{
    public interface ITourRepository
    {
        public Task<List<Tour>> GetAllAsync();
        public Task<Tour> GetByIdAsync(int id);
        public Task AddTourAsync(Tour tour);
        public Task UpdateTourAsync(Tour tour);
        public Task DeleteTourAsync(int id);
        public Task SaveAsync();
    }
}
