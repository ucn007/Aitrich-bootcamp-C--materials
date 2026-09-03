using Exercise.Dtos;

namespace Exercise.Interfaces;

public interface IDestinationService
{
  
    Task<List<DestinationCreate>> GetAllAsync();
    Task<DestinationCreate?> GetByIdAsync(int id);
    Task<DestinationCreate> CreateAsync(DestinationCreate dto);
    Task<bool> UpdateAsync(DestinationUpdate dto);
    Task<bool> DeleteAsync(int id);
}