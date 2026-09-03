using Destination.Dto;

namespace Destination.Interface
{
    public interface IDestiService
    {
        Task<List<DestinationDto>> GetAllAsync();   // Get all destinations

        Task<DestinationDto?> GetByIdAsync(int id);  // Get single destination

        Task<bool> AddDestiAsync(DestinationDto destinationDto);

        Task<bool> UpdateDestiAsync(DestinationDto destinationDto);

        Task<bool> DeleteDestiAsync(int id);
    }
}
