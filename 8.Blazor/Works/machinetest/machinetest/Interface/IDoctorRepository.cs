using machinetest.Model;

namespace machinetest.Interface;

public interface IDoctorRepository
{
    
    Task<List<Doctor>> GetAllAsync();

    Task<Doctor?> GetByIdAsync(int id);

    Task<Doctor> CreateAsync(Doctor doctor);

    Task<Doctor?> UpdateAsync(Doctor doctor);

    Task<bool> DeleteAsync(int id);
}
