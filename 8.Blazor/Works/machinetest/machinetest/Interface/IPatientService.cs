using machinetest.DTOs;

namespace machinetest.Interface;

public interface IPatientService
{
    Task<List<PatientDto>> GetAllAsync();

    Task<PatientDto?> GetByIdAsync(int id);

    Task<PatientDto> CreateAsync(PatientDto patientDto);

    Task<PatientDto?> UpdateAsync(int id, PatientDto patientDto);

    Task<bool> DeleteAsync(int id);
}