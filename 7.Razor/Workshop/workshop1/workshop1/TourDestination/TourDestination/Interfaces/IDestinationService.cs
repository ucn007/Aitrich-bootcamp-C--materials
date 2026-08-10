using TourDestination.Dtos;

using TourDestination.Model;

namespace TourDestination.Interfaces
{
   
            public interface IDestinationService
            {
                Task<List<DestinationcreationDto>> GetAllAsync();
                Task<DestinationcreationDto?> GetByIdAsync(int id);
                Task<DestinationcreationDto> CreateAsync(DestinationcreationDto dto);
                Task<bool> UpdateAsync(DestinationDto.DestinationUpdateDto dto);
                Task<bool> DeleteAsync(int id);
            }
        }

    

