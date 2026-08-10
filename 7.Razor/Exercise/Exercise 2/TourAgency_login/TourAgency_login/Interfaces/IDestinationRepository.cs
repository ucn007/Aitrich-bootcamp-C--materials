using TourConsultant_login.Model;

namespace TourConsultant_login.Interfaces
{
    public interface IDestinationRepository
    {
        Task<List<Destination>> GetAllDestinationAsync();
    }
}
