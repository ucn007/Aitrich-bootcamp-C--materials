using machinetest.Interfaces;
using machinetest.Model;
using Microsoft.EntityFrameworkCore;

namespace machinetest.Repository;

public class BookRepository: IBookRepository
{
    private readonly ApplicationDbContext _context;
    
    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
        
    }
    
    public async Task<List<book>> GetAllAsync()
    {
        return await _context.books
            .ToListAsync();
    }
    
    public async Task<book?> GetByIdAsync(int id)
    {
        return await _context.books 
            .FirstOrDefaultAsync(x => x.id == id);
    }
    
    public async Task AddAsync(book book)
    {
        await _context.books.AddAsync(book);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(book book)
    {
        _context.books.Update(book);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        var book = await _context.books
            .FirstOrDefaultAsync(x => x.id == id);

        if (book == null)
            return;

        _context.books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.books
            .AnyAsync(x => x.id == id);
    }
}