using AutoMapper;
using machinetest.Dtos;
using machinetest.Interfaces;
using machinetest.Model;

namespace machinetest.Services;

public class BookService:IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    
    public async Task<List<BookCreateDto>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllAsync();

        return _mapper.Map<List<BookCreateDto>>(books);
    }
    
    
    
    
    
    public async Task<BookCreateDto?> GetByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book == null)
            return null;

        return _mapper.Map<BookCreateDto>(book);
    }

    public async Task<BookCreateDto> CreateAsync(BookCreateDto dto)
    {
        
        var book = _mapper.Map<book>(dto);
        
        await _bookRepository.AddAsync(book);

        return _mapper.Map<BookCreateDto>(book);
    }

    public async Task<bool> UpdateAsync(BookUpdateDto dto)
    {
        var book = await _bookRepository.GetByIdAsync(dto.id);

        if (book == null)
            return false;

        
        book.title = dto.title; 
        book.author = dto.author;
        book.quantity = dto.quantity;

        await _bookRepository.UpdateAsync(book);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!await _bookRepository.ExistsAsync(id))
            return false;

        await _bookRepository.DeleteAsync(id);

        return true;
    }
}