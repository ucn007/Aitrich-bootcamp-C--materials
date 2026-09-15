using machinetest.DTOs;

namespace machinetest.Interface;

public interface IAppointmentService
{
    Task<List<AppointmentDto>> GetAllAsync();

    Task<AppointmentDto?> GetByIdAsync(int id);

    Task<AppointmentDto> CreateAsync(AppointmentDto dto);

    Task<bool> DeleteAsync(int id);
}