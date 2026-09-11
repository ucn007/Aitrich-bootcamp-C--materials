using AutoMapper;
using BlazorApp2.DTOs;
using BlazorApp2.Model;
using BlazorApp2.Repositories.Interfaces;
using BlazorApp2.Services.Interfaces;

namespace BlazorApp2.Services;

public class TourService : ITourService
{
    private readonly ITourRepository _tourRepository;
    private readonly IMapper _mapper;

    public TourService(
        ITourRepository tourRepository,
        IMapper mapper)
    {
        _tourRepository = tourRepository;
        _mapper = mapper;
    }

    public async Task<List<TourCreateDto>> GetAllTours()
    {
        var tours = await _tourRepository.GetAllTours();

        return _mapper.Map<List<TourCreateDto>>(tours);
    }

    public async Task<TourCreateDto> AddTour(Tours tour)
    {
        var addedTour = await _tourRepository.InsertTour(tour);

        return _mapper.Map<TourCreateDto>(addedTour);
    }

    public async Task<Tours> DeleteTour(Tours tour)
    {
        return await _tourRepository.DeleteTour(tour);
    }

    public async Task<TourUpdateDto> UpdateTour(Tours tour)
    {
        var updatedTour = await _tourRepository.UpdateTour(tour);

        return _mapper.Map<TourUpdateDto>(updatedTour);
    }
}