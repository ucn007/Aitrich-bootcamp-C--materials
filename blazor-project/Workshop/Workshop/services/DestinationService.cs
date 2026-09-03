using AutoMapper;
using Workshop.Dtos;
using Workshop.Interfaces;
using Workshop.Model;

namespace Workshop.Services;

public class DestinationService : IDestinationService
{
    private readonly IDestinationRepository _repo;
    private readonly IMapper _mapper;

    public DestinationService(
        IDestinationRepository repo,
        IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<DestinationCreateDto> CreateAsync(DestinationCreateDto dto)
    {
        var entity = _mapper.Map<Destination>(dto);

        await _repo.AddAsync(entity);

        return _mapper.Map<DestinationCreateDto>(entity);
    }

    public async Task<List<DestinationCreateDto>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        return _mapper.Map<List<DestinationCreateDto>>(list);
    }

    public async Task<DestinationCreateDto?> GetByIdAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);

        return entity == null
            ? null
            : _mapper.Map<DestinationCreateDto>(entity);
    }

    public async Task<bool> UpdateAsync(DestinationUpdateDto dto)
    {
        var entity = await _repo.GetByIdAsync(dto.Id);

        if (entity == null)
            return false;

        entity.Name = dto.Name;
        entity.City = dto.City;

        if (dto.ImageFile != null && dto.ImageFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/images"
            );

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName =
                Guid.NewGuid() + Path.GetExtension(dto.ImageFile.FileName);

            var filePath = Path.Combine(uploadsFolder, fileName);

            await using (var stream = new FileStream(
                filePath,
                FileMode.Create))
            {
                await dto.ImageFile.CopyToAsync(stream);
            }

            entity.ImagePath = "/images/" + fileName;
        }

        await _repo.UpdateAsync(entity);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!await _repo.ExistsAsync(id))
            return false;

        await _repo.DeleteAsync(id);

        return true;
    }
}