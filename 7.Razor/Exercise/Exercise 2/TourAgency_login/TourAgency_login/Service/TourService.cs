using TourConsultant_login.Dtos;
using TourConsultant_login.Interfaces;
using TourConsultant_login.Model;

namespace TourConsultant_login.Service
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _repository;

        public TourService(ITourRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Tour>> GetAllTours()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Tour?> GetTour(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateTour(TourRegisterDto dto)
        {
            var tour = new Tour
            {
                TourName = dto.TourName,
                TourDescription = dto.TourDescription,
                NoOfNights = dto.NoOfNights,
                Price = dto.Price,
                DepartureDate = dto.DepartureDate,
                ArrivalDate = dto.ArrivalDate,
                DestinationId = dto.DestinationId   
            };

            await _repository.AddAsync(tour);
        }


        public async Task UpdateTour(Guid id, TourUpdateDto dto)
        {
            var existingTour = await _repository.GetByIdAsync(id);

            if (existingTour == null)
                return;

            existingTour.TourName = dto.TourName;
            existingTour.TourDescription = dto.TourDescription;
            existingTour.NoOfNights = dto.NoOfNights;
            existingTour.Price = dto.Price;
            existingTour.DepartureDate = dto.DepartureDate;
            existingTour.ArrivalDate = dto.ArrivalDate;
            existingTour.DestinationId = dto.DestinationId; // ✅ important

            await _repository.UpdateAsync(existingTour);
        }


        public async Task<TourUpdateDto?> GetTourById(Guid id)
        {
            var tour = await _repository.GetByIdAsync(id);

            if (tour == null)
                return null;

            return new TourUpdateDto
            {
                Id = tour.Id,
                TourName = tour.TourName,
                TourDescription = tour.TourDescription,
                NoOfNights = tour.NoOfNights,
                Price = tour.Price,
                DepartureDate = tour.DepartureDate,
                ArrivalDate = tour.ArrivalDate,
                DestinationId = tour.DestinationId   
            };
        }

        public async Task DeleteTour(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

       
    }
}
