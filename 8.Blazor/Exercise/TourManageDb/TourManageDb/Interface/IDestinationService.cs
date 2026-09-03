using TourManageDb.Model;

namespace TourManageDb.Interface
{
    public interface IDestinationService
    {
        public Task<List<Destination>> GetAllAsync();
    }
}
