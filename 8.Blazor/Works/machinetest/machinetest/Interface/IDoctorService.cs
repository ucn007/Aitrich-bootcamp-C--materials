using machinetest.DTOs;

namespace machinetest.Interface;

public interface IDoctorService
{
    Task<List<DoctorDto>> GetAllAsync();

    Task<DoctorDto?> GetByIdAsync(int id);

    Task<DoctorDto> CreateAsync(DoctorDto doctorDto);

    Task<DoctorDto?> UpdateAsync(int id, DoctorDto doctorDto);

    Task<bool> DeleteAsync(int id);
}