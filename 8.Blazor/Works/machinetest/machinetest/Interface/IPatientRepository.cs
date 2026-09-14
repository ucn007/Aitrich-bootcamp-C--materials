using machinetest.Model;

namespace machinetest.Interface;

public interface IPatientRepository
{
    Task<List<Patient>> GetAllAsync();

    Task<Patient?> GetByIdAsync(int id);

    Task<Patient> CreateAsync(Patient patient);

    Task<Patient?> UpdateAsync(Patient patient);

    Task<bool> DeleteAsync(int id);
}