using Exercise.Dtos;

namespace Exercise.Interfaces;

public interface ITourService
{
    Task<List<TourCreate>> GetAllAsync();

    Task<TourCreate?> GetByIdAsync(string id);

    Task<TourCreate> CreateAsync(TourCreate dto);

    Task<bool> UpdateAsync(TourUpdate dto);

    Task<bool> DeleteAsync(string id);
}