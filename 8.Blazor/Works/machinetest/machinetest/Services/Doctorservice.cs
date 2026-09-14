using machinetest.DTOs;
using machinetest.Interface;
using machinetest.Model;

namespace machinetest.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<List<DoctorDto>> GetAllAsync()
    {
        var doctors = await _doctorRepository.GetAllAsync();

        return doctors
            .Select(MapToDto)
            .ToList();
    }

    public async Task<DoctorDto?> GetByIdAsync(int id)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);

        if (doctor == null)
        {
            return null;
        }

        return MapToDto(doctor);
    }

    public async Task<DoctorDto> CreateAsync(DoctorDto doctorDto)
    {
        var doctor = new Doctor
        {
            Name = doctorDto.Name,
            Specialization = doctorDto.Specialization,
            Department = doctorDto.Department,
            ConsultationFee = doctorDto.ConsultationFee,
            Available = doctorDto.Available
        };

        var createdDoctor =
            await _doctorRepository.CreateAsync(doctor);

        return MapToDto(createdDoctor);
    }

    public async Task<DoctorDto?> UpdateAsync(
        int id,
        DoctorDto doctorDto)
    {
        var doctor = new Doctor
        {
            Id = id,
            Name = doctorDto.Name,
            Specialization = doctorDto.Specialization,
            Department = doctorDto.Department,
            ConsultationFee = doctorDto.ConsultationFee,
            Available = doctorDto.Available
        };

        var updatedDoctor =
            await _doctorRepository.UpdateAsync(doctor);

        if (updatedDoctor == null)
        {
            return null;
        }

        return MapToDto(updatedDoctor);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _doctorRepository.DeleteAsync(id);
    }

    private static DoctorDto MapToDto(Doctor doctor)
    {
        return new DoctorDto
        {
            Name = doctor.Name,
            Specialization = doctor.Specialization,
            Department = doctor.Department,
            ConsultationFee = doctor.ConsultationFee,
            Available = doctor.Available
        };
    }
}