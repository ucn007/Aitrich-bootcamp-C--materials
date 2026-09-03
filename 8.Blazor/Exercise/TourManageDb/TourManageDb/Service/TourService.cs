using TourManageDb.DTO;
using TourManageDb.Interface;
using TourManageDb.Model;
using TourManageDb.Repository;

namespace TourManageDb.Service
{
    public class TourService : ITourService
    {
        private readonly ITourRepository repository;
        public TourService(ITourRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Tour>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Tour?> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task AddTourAsync(TourDto dto)
        {
            var tour = new Tour
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                DestinationId = dto.DestinationId
            };
            await repository.AddTourAsync(tour);
            await repository.SaveAsync();
        }

        public async Task UpdateTourAsync(TourDto dto)
        {
            var tour = await repository.GetByIdAsync(dto.Id);
            if (tour == null)
            {
                throw new Exception("Tour not found");
            }

            tour.Title = dto.Title;
            tour.Description = dto.Description;
            tour.Price = dto.Price;
            tour.DestinationId = dto.DestinationId;

            await repository.UpdateTourAsync(tour);
            await repository.SaveAsync();
        }

        public async Task DeleteTourAsync(int id)
        {
            await repository.DeleteTourAsync(id);
            await repository.SaveAsync();
        }
    }
}
