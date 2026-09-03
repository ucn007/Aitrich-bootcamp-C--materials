using TourManageDb.DTO;
using TourManageDb.Model;

namespace TourManageDb.Interface
{
    public interface ITourService
    {
        public Task<List<Tour>> GetAllAsync();
        public Task<Tour> GetByIdAsync(int id);
        public Task AddTourAsync(TourDto dto);
        public Task UpdateTourAsync(TourDto dto);
        public Task DeleteTourAsync(int id);
    }
}
