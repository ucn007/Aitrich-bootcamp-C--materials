using AutoMapper;
using TourManagement.Dto;
using TourManagement.Interface;
using TourManagement.Model;

namespace TourManagement.Service
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _repo;
        private readonly IMapper _mapper;

        public TourService(ITourRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task AddAsync(TourDto dto)
        {
            var entity = _mapper.Map<Tour>(dto);
            await _repo.AddAsync(entity);
            //throw new NotImplementedException();
        }

        public async Task<List<TourDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<TourDto>>(data);
            //throw new NotImplementedException();
        }
    }
}
