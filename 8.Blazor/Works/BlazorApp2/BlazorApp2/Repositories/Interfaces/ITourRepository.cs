using BlazorApp2.Model;

namespace BlazorApp2.Repositories.Interfaces;

public interface ITourRepository
{
    Task<List<Tours>> GetAllTours();
    Task<Tours> GetTourById(int id);
    Task<Tours> InsertTour(Tours tour);
    Task<Tours> UpdateTour(Tours tour);
    Task<Tours> DeleteTour(Tours tour);
}