using TourConsultant_login.Model;

namespace TourConsultant_login.Interfaces
{
    public interface IDestinationService
    {
        Task<List<Destination>> GetAllDestination();
    }
}
