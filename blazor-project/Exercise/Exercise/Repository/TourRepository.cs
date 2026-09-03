using Exercise.Interfaces;
using Exercise.Model;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Repository;

public class TourRepository:ITourRepository
{
    private readonly ApplicationDbContext _context;

    public TourRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TourPackage>> GetAllAsync()
    {
        return await _context.TourPackages
            .Include(x => x.Destination)
            .ToListAsync();
    }

    public async Task<TourPackage?> GetByIdAsync(string id)
    {
        return await _context.TourPackages
            .Include(x => x.Destination)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(TourPackage tour)
    {
        await _context.TourPackages.AddAsync(tour);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TourPackage tour)
    {
        _context.TourPackages.Update(tour);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var tour = await _context.TourPackages
            .FirstOrDefaultAsync(x => x.Id == id);

        if (tour == null)
            return;

        _context.TourPackages.Remove(tour);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(string id)
    {
        return await _context.TourPackages
            .AnyAsync(x => x.Id == id);
    }
}