using Exercise.Model;

namespace Exercise.Interfaces;

public interface ITourRepository
{
    Task<List<TourPackage>> GetAllAsync();

    Task<TourPackage?> GetByIdAsync(string id);

    Task AddAsync(TourPackage tour);

    Task UpdateAsync(TourPackage tour);

    Task DeleteAsync(string id);

    Task<bool> ExistsAsync(string id);
}