using Workshop.Dtos;

namespace Workshop.Interfaces;

public interface IDestinationService
{
    Task<List<DestinationCreateDto>> GetAllAsync();

    Task<DestinationCreateDto?> GetByIdAsync(int id);

    Task<DestinationCreateDto> CreateAsync(DestinationCreateDto dto);

    Task<bool> UpdateAsync(DestinationUpdateDto dto);

    Task<bool> DeleteAsync(int id);
}