using BlazorApp2.Model;
using BlazorApp2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Repositories;

public class TourRepository: ITourRepository
{
    private readonly ApplicationDbContext _context;
    
    public TourRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Tours>> GetAllTours()
    {
        return await _context.Tours.ToListAsync();
    }

    public async Task<Tours> GetTourById(int id)
    {
        return await _context.Tours.FindAsync(id);
        
    }

    public async Task<Tours> InsertTour(Tours tour)
    {
        _context.Tours.Add(tour);

        await _context.SaveChangesAsync();

        return tour;
    }

    public Task<Tours> DeleteTour(Tours tour)
    {
         var Tour = _context.Tours.Find(tour.Id);
         if (Tour != null)
             {
             _context.Tours.Remove(Tour);
             _context.SaveChanges();
             }
         return Task.FromResult(tour);
      
    }

    public async Task<Tours> UpdateTour(Tours tour)
    {
        _context.Tours.Update(tour);
        await _context.SaveChangesAsync();
        return tour;
    }
    
}