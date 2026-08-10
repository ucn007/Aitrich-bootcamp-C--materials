using TravelsDb.Interfaces;
using TravelsDb.Models;

namespace TravelsDb.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;

        public DestinationService(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public async Task<List<Destination>> GetAllAsync()
        {
            return await _destinationRepository.GetAllAsync();
        }

        public async Task AddAsync(Destination destination)
        {
            await _destinationRepository.AddAsync(destination);
            await _destinationRepository.SaveAsync();
        }

        public async Task UpdateAsync(Destination destination)
        {
            await _destinationRepository.UpdateAsync(destination);
            await _destinationRepository.SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            await _destinationRepository.DeleteAsync(id);
            await _destinationRepository.SaveAsync();
        }
    }
}
