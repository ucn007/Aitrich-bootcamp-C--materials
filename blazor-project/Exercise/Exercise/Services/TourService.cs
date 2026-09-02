using AutoMapper;
using Exercise.Dtos;
using Exercise.Interfaces;
using Exercise.Model;

namespace Exercise.Services;

public class TourService: ITourService
{
      private readonly ITourRepository _repo;
    private readonly IDestinationRepository _destinationRepository;
    private readonly IMapper _mapper;

    public TourService(
        ITourRepository repo,
        IDestinationRepository destinationRepository,
        IMapper mapper)
    {
        _repo = repo;
        _destinationRepository = destinationRepository;
        _mapper = mapper;
    }

    public async Task<List<TourCreate>> GetAllAsync()
    {
        var tours = await _repo.GetAllAsync();

        return _mapper.Map<List<TourCreate>>(tours);
    }

    public async Task<TourCreate?> GetByIdAsync(string id)
    {
        var tour = await _repo.GetByIdAsync(id);

        if (tour == null)
            return null;

        return _mapper.Map<TourCreate>(tour);
    }

    public async Task<TourCreate> CreateAsync(TourCreate dto)
    {
        var destination = await _destinationRepository
            .GetByIdAsync(dto.DestinationId);

        if (destination == null)
            throw new ArgumentException("Destination not found.");

        var tour = _mapper.Map<TourPackage>(dto);

        tour.Id = Guid.NewGuid().ToString();

        tour.DestinationId = destination.Id;
        tour.DestinationName = destination.Name;

        await _repo.AddAsync(tour);

        return _mapper.Map<TourCreate>(tour);
    }

    public async Task<bool> UpdateAsync(TourUpdate dto)
    {
        var tour = await _repo.GetByIdAsync(dto.Id);

        if (tour == null)
            return false;

        var destination = await _destinationRepository
            .GetByIdAsync(dto.DestinationId);

        if (destination == null)
            return false;

        tour.Name = dto.Name;
        tour.DestinationId = destination.Id;
        tour.DestinationName = destination.Name;
        tour.Days = dto.Days;
        tour.Seats = dto.Seats;
        tour.ImagePath = dto.ImagePath;

        await _repo.UpdateAsync(tour);

        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        if (!await _repo.ExistsAsync(id))
            return false;

        await _repo.DeleteAsync(id);

        return true;
    }
}