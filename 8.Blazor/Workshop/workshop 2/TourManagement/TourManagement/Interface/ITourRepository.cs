using TourManagement.Model;

namespace TourManagement.Interface
{
    public interface ITourRepository
    {
        Task<List<Tour>> GetAllAsync();
        Task AddAsync(Tour tour);
    }
}
