using TourManagement.Dto;
using TourManagement.Model;

namespace TourManagement.Interface
{
    public interface IDestinationService
    {
        Task<List<DestinationDto>> GetAllAsync();
        Task<DestinationDto> GetByIdAsync(int id);
        Task AddAsync(DestinationDto dto);
        Task UpdateAsync(DestinationDto dto);
        Task DeleteAsync(int id);
    }
}
