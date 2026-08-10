using TourConsultant_login.Interfaces;
using TourConsultant_login.Model;

namespace TourConsultant_login.Service
{
    public class DestinationService : IDestinationService
    {


        private readonly IDestinationRepository _repository;

        public DestinationService(IDestinationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Destination>> GetAllDestination()
        {
            return await _repository.GetAllDestinationAsync();
        }

    }
}
