using Destination.Dto;
using Destination.Model;

namespace Destination.Interface
{
    public interface ITourService
    {
        Task CreateTourAsync(Tour tour);
        Task<List<TourDto>> GetAllToursAsync();
    }
}