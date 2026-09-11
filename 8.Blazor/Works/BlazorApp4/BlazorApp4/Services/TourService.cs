using AutoMapper;
using BlazorApp4.DTOs;
using BlazorApp4.Interfaces;
using BlazorApp4.Model;

namespace BlazorApp4.Services;

public class TourService:ITourService
{
    private readonly ITourRepository _tourRepository; private readonly IMapper _mapper;

    public TourService(ITourRepository tourRepository, IMapper mapper)
    {
        _tourRepository = tourRepository; _mapper = mapper;
    }

    public async Task<IEnumerable<Tour>> GetAllToursAsync()
    {
        return await _tourRepository.GetAllToursAsync();
    }

    public async Task<Tour?> GetTourByIdAsync(int id)
    {
        return await _tourRepository.GetTourByIdAsync(id);
    }

    public async Task<Tour> CreateTourAsync(TourCreateDto dto)
    {
        
        var tour = _mapper.Map<Tour>(dto); return await _tourRepository.AddTourAsync(tour);
    }

    public async Task<bool> UpdateTourAsync(int id, TourUpdateDto dto)
    {
        var tour = await _tourRepository.GetTourByIdAsync(id); if (tour == null) return false; _mapper.Map(dto, tour); return await _tourRepository.UpdateTourAsync(tour);
    }

    public async Task<bool> DeleteTourAsync(int id)
    {
        return await _tourRepository.DeleteTourAsync(id);
    }
}