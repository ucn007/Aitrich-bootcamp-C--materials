using Destination.Model;

namespace Destination.Interface
{
    public interface ITourRepository
    {
        Task AddTourAsync(Tour tour);
        Task<List<Tour>> GetAllToursAsync();
    }
}