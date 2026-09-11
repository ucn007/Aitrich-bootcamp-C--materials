using BlazorApp4.DTOs;
using BlazorApp4.Model;

namespace BlazorApp4.Interfaces;

public interface ITourService
{
    Task<IEnumerable<Tour>> GetAllToursAsync();
    
    Task<Tour?> GetTourByIdAsync(int id); 
    
    Task<Tour> CreateTourAsync(TourCreateDto dto); 
    
    Task<bool> UpdateTourAsync(int id, TourUpdateDto dto); 
    
    Task<bool> DeleteTourAsync(int id);
    
}