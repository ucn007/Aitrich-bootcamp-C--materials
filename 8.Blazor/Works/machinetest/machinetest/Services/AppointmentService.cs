using machinetest.DTOs;
 
using machinetest.Interface;
using machinetest.Model;

namespace machinetest.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;

    public AppointmentService(
        IAppointmentRepository appointmentRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository)
    {
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
    }

    public async Task<List<AppointmentDto>> GetAllAsync()
    {
        var appointments =
            await _appointmentRepository.GetAllAsync();

        return appointments
            .Select(MapToDto)
            .ToList();
    }

    public async Task<AppointmentDto?> GetByIdAsync(int id)
    {
        var appointment =
            await _appointmentRepository.GetByIdAsync(id);

        if (appointment == null)
        {
            return null;
        }

        return MapToDto(appointment);
    }

    public async Task<AppointmentDto> CreateAsync(
        AppointmentDto dto)
    {
        var patient =
            await _patientRepository.GetByIdAsync(dto.PatientId);

        if (patient == null)
        {
            throw new Exception("Patient not found.");
        }

        var doctor =
            await _doctorRepository.GetByIdAsync(dto.DoctorId);

        if (doctor == null)
        {
            throw new Exception("Doctor not found.");
        }

        var appointment = new Appoinment
        {
            PatientId = patient.Id,
            PatientName = patient.PatientName,

            DoctorId = doctor.Id,
            DoctorName = doctor.Name,

            AppointmentDate = dto.AppointmentDate,
            AppoinmentTime = dto.AppoinmentTime
        };

        var created =
            await _appointmentRepository.CreateAsync(
                appointment);

        return MapToDto(created);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _appointmentRepository.DeleteAsync(id);
    }

    private static AppointmentDto MapToDto(
        Appoinment appointment)
    {
        return new AppointmentDto
        {
            Id = appointment.Id,

            PatientId = appointment.PatientId,
            PatientName = appointment.PatientName,

            DoctorId = appointment.DoctorId,
            DoctorName = appointment.DoctorName,

            AppointmentDate = appointment.AppointmentDate,
            AppoinmentTime = appointment.AppoinmentTime
        };
    }
}