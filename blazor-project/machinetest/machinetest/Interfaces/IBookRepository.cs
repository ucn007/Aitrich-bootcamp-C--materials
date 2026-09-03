using machinetest.Model;

namespace machinetest.Interfaces;

public interface IBookRepository
{
    Task<List<book>> GetAllAsync();

    Task<book?> GetByIdAsync(int id);

    Task AddAsync(book book);

    Task UpdateAsync(book tour);

    Task DeleteAsync(int id);

    Task<bool> ExistsAsync(int id);
}