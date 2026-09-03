using System.Net.Mime;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Dtos;
using WebApplication4.Model;

namespace WebApplication4.Service;

public class TourService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public TourService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TourDto>> GetAllAsync(string? searchItem = null)
    {
        var query = _context.Tour.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchItem))
        {
            query = query.Where(t =>
                t.Name.Contains(searchItem));
        }

        var tours = await query.ToListAsync();

        return _mapper.Map<List<TourDto>>(tours);
    }

    public async Task<TourDto> GetByIdAsync(int id)
    {
        var tour = await  _context.Tour.FindAsync(id);
        return _mapper.Map<TourDto>(tour);
    }

    public async Task AddTourAsync(TourDto tourDto)
    {
        var tour = _mapper.Map<Tours>(tourDto);
        _context.Tour.Add(tour);
        await _context.SaveChangesAsync();
        
    }

    public async Task updateTourAsync(int id, TourDto tourDto)
    {
        var tour = await  _context.Tour.FindAsync(id);
        if (tour == null) return;
        _mapper.Map(tourDto, tour);
        _context.Tour.Update(tour);
        await _context.SaveChangesAsync();
    }

    public async Task deleteTourAsync(int id)
    {
        var tour = await  _context.Tour.FindAsync(id);
        if (tour == null) return;
        _context.Tour.Remove(tour);
        await _context.SaveChangesAsync();
    }
    

}