using AutoMapper;
using TourDestination.DestinationDto;
using TourDestination.Dtos;
using TourDestination.Interfaces;
using TourDestination.Model;

namespace TourDestination.services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repo;
        private readonly IMapper _mapper;

        public DestinationService(IDestinationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<DestinationcreationDto> CreateAsync(DestinationcreationDto dto)
        {
            var entity = _mapper.Map<Destination>(dto);
            await _repo.AddAsync(entity);
            return _mapper.Map<DestinationcreationDto>(entity);
        }

        public async Task<List<DestinationcreationDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<List<DestinationcreationDto>>(list);
        }

        public async Task<DestinationcreationDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<DestinationcreationDto>(entity);
        }

        public async Task<bool> UpdateAsync(DestinationUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);
            if (entity == null)
                return false;

            // Update basic fields
            entity.Name = dto.Name;
            entity.City = dto.City;

            // If new image selected
            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() +
                               Path.GetExtension(dto.ImageFile.FileName);

                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream);
                }

                entity.ImagePath = "/images/" + fileName;
            }

            // If no new image → do nothing (old image remains)

            await _repo.UpdateAsync(entity);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _repo.ExistsAsync(id)) return false;
            await _repo.DeleteAsync(id);
            return true;
        }
    }
}

