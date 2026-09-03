using machinetest.Dtos;

namespace machinetest.Interfaces;

public interface IBookService
{
    Task<List<BookCreateDto>> GetAllAsync();

    Task<BookCreateDto?> GetByIdAsync(int id);

    Task<BookCreateDto> CreateAsync(BookCreateDto dto);

    Task<bool> UpdateAsync(BookUpdateDto dto);

    Task<bool> DeleteAsync(int id);
}