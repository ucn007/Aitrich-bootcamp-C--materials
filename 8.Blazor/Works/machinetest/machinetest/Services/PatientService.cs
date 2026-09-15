 
    
    using machinetest.DTOs;
using machinetest.Interface;
using machinetest.Model;

namespace machinetest.Services;

public class PatientService: IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<List<PatientDto>> GetAllAsync()
    {
        var patients = await _patientRepository.GetAllAsync();

        return patients.Select(MapToDto).ToList();
    }

    public async Task<PatientDto?> GetByIdAsync(int id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);

        if (patient == null)
        {
            return null;
        }

        return MapToDto(patient);
    }

    public async Task<PatientDto> CreateAsync(PatientDto patientDto)
    {
        var patient = new Patient
        {
            PatientName = patientDto.PatientName,
            Phone = patientDto.Phone,
            Email = patientDto.Email,
            Gender = patientDto.Gender,
            Dob = patientDto.Dob
        };

        var createdPatient = await _patientRepository.CreateAsync(patient);

        return MapToDto(createdPatient);
    }

    public async Task<PatientDto?> UpdateAsync(
        int id,
        PatientDto patientDto)
    {
        var patient = new Patient
        {
            Id = id,
            PatientName = patientDto.PatientName,
            Phone = patientDto.Phone,
            Email = patientDto.Email,
            Gender = patientDto.Gender,
            Dob = patientDto.Dob
        };

        var updatedPatient = await _patientRepository.UpdateAsync(patient);

        if (updatedPatient == null)
        {
            return null;
        }

        return MapToDto(updatedPatient);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _patientRepository.DeleteAsync(id);
    }

    private static PatientDto MapToDto(Patient patient)
    {
        return new PatientDto
        {
            PatientName = patient.PatientName,
            Phone = patient.Phone,
            Email = patient.Email,
            Gender = patient.Gender,
            Dob = patient.Dob
        };
    }
}
