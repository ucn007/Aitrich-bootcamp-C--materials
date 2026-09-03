using TourManagement.Dto;

namespace TourManagement.Interface
{
    public interface ITourService
    {
        Task<List<TourDto>> GetAllAsync();
        Task AddAsync(TourDto dto);
    }
}
