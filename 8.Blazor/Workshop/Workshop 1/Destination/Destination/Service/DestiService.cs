using AutoMapper;
using Destination.Dto;
using Destination.Interface;
using Destination.Model;

namespace Destination.Service
{
    public class DestiService : IDestiService
    {
        private readonly IDestiRepository _destiRepository;
        private readonly IMapper _mapper;

        public DestiService(IDestiRepository destiRepository, IMapper mapper)
        {
            _destiRepository = destiRepository;
            _mapper = mapper;
        }

        // ✅ Add Destination
        public async Task<bool> AddDestiAsync(DestinationDto destinationDto)
        {
            var desti = _mapper.Map<Destinationn>(destinationDto);
            await _destiRepository.AddAsync(desti);
            return true;
        }

        // ✅ Delete Destination
        public async Task<bool> DeleteDestiAsync(int id)
        {
            await _destiRepository.DeleteAsync(id);
            return true;
        }

        // ✅ Get All Destinations
        public async Task<List<DestinationDto>> GetAllAsync()
        {
            var destiList = await _destiRepository.GetAllAsync();
            return _mapper.Map<List<DestinationDto>>(destiList);
        }

        // ✅ Get Destination By Id (Single)
        public async Task<DestinationDto?> GetByIdAsync(int id)
        {
            var desti = await _destiRepository.GetByIdAsync(id);

            if (desti == null)
                return null;

            return _mapper.Map<DestinationDto>(desti);
        }

        // ✅ Update Destination
        public async Task<bool> UpdateDestiAsync(DestinationDto destinationDto)
        {
            var desti = await _destiRepository.GetByIdAsync(destinationDto.Id);

            if (desti == null)
                return false;

            _mapper.Map(destinationDto, desti);
            await _destiRepository.UpdateAsync(desti);

            return true;
        }
    }
}
