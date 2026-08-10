using TourConsultant_login.Dtos;
using TourConsultant_login.Model;

namespace TourConsultant_login.Interfaces
{

    public interface ITourService
    {
        Task<List<Tour>> GetAllTours();

        Task<TourUpdateDto?> GetTourById(Guid id);  // ✅ for Edit page

        Task CreateTour(TourRegisterDto dto);

        Task UpdateTour(Guid id, TourUpdateDto dto); // ✅ correct

        Task DeleteTour(Guid id);
    }
}

