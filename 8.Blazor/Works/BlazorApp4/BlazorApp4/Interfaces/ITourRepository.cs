using BlazorApp4.DTOs;
using BlazorApp4.Model;

namespace BlazorApp4.Interfaces;

public interface ITourRepository
{
    Task<IEnumerable<Tour>> GetAllToursAsync();
    
    Task<Tour?> GetTourByIdAsync(int id);
    
    Task<Tour> AddTourAsync(Tour tour); 
    
    Task<bool> UpdateTourAsync(Tour tour); 
    
    Task<bool> DeleteTourAsync(int id);
}