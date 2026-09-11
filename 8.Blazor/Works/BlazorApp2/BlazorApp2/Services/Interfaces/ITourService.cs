using BlazorApp2.DTOs;
using BlazorApp2.Model;

namespace BlazorApp2.Services.Interfaces;

public interface ITourService
{
Task <List<TourCreateDto>> GetAllTours();
Task<TourCreateDto> AddTour(Tours tour);
Task<Tours> DeleteTour(Tours tour);
Task<TourUpdateDto> UpdateTour(Tours tour);

}