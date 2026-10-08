using JobApplication.DTOs.Job;

namespace JobApplication.Interfaces.Services;

public interface IJobServices
{
    Task<JobResponseDto> CreateAsync(
        CreateJobDto dto,
        Guid companyId);

    Task<JobResponseDto?> GetByIdAsync(
        Guid jobId);

    Task<IEnumerable<JobResponseDto>> GetAllAsync();

    Task<IEnumerable<JobResponseDto>> GetByCompanyIdAsync(
        Guid companyId);

    Task<JobResponseDto?> UpdateAsync(
        Guid jobId,
        UpdateJobDto dto,
        Guid companyId);

    Task<bool> DeleteAsync(
        Guid jobId,
        Guid companyId); 
}