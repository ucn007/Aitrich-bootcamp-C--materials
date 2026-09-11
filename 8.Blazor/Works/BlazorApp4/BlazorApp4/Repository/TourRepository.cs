
using BlazorApp4.Interfaces;
using BlazorApp4.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Repository;

public class TourRepository : ITourRepository
{
    private readonly ApplicationDbContext _context;

    public TourRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tour>> GetAllToursAsync()
    {
        return await _context.Tours.ToListAsync();
    }

    public async Task<Tour?> GetTourByIdAsync(int id)
    {
        return await _context.Tours
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tour> AddTourAsync(Tour tour)
    {
        _context.Tours.Add(tour);

        await _context.SaveChangesAsync();

        return tour;
    }

    public async Task<bool> UpdateTourAsync(Tour tour)
    {
        var existingTour = await _context.Tours
            .FindAsync(tour.Id);

        if (existingTour == null)
            return false;

        existingTour.Name = tour.Name;
        existingTour.Description = tour.Description;
        existingTour.Destination = tour.Destination;
        existingTour.Location = tour.Location;
        existingTour.Price = tour.Price;
        existingTour.DurationDays = tour.DurationDays;
        existingTour.MaxParticipants = tour.MaxParticipants;
        existingTour.ImageUrl = tour.ImageUrl;
        existingTour.IsAvailable = tour.IsAvailable;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteTourAsync(int id)
    {
        var tour = await _context.Tours.FindAsync(id);

        if (tour == null)
            return false;

        _context.Tours.Remove(tour);

        await _context.SaveChangesAsync();

        return true;
    }
}
