using machinetest.Model;

namespace machinetest.Interface;

public interface IAppointmentRepository
{
    Task<List<Appoinment>> GetAllAsync();

    Task<Appoinment?> GetByIdAsync(int id);

    Task<Appoinment> CreateAsync(Appoinment appointment);

    Task<bool> DeleteAsync(int id);
}