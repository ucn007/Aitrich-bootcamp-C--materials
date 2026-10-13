using JobApplication.DTOs.Job;
using JobApplication.Interfaces.Repository;
using JobApplication.Interfaces.Services;
using JobApplication.Models;

namespace JobApplication.Services;

public class JobServices:IJobServices
{
    private readonly IJobRepository _jobRepository;
    public JobServices(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<JobResponseDto> CreateAsync(
        CreateJobDto dto,
        Guid companyId)
    {
        var job = new Job
        {
            JobId = Guid.NewGuid(),
            JobTitle = dto.JobTitle,
            Description = dto.Description,
            Experience = dto.Experience,
            JobType = dto.JobType,  
            CompId = companyId,
            CreatedAt = DateTime.UtcNow
        };
        var createdJob = await _jobRepository.AddAsync(job); return MapToResponse(createdJob);
    }

   public async Task<JobResponseDto?> GetByIdAsync(
        Guid jobId)
    {
        var job = await _jobRepository.GetByIdAsync(jobId);
        if (job == null)
            return null;
        return MapToResponse(job);
    }

    public async Task<IEnumerable<JobResponseDto>> GetAllAsync()
    {
        var jobs = await _jobRepository.GetAllAsync();
        return jobs.Select(MapToResponse);
    }

    public async Task<IEnumerable<JobResponseDto>> GetByCompanyIdAsync(
        Guid companyId)
    {
        var jobs = await _jobRepository .GetByCompanyIdAsync(companyId);
        return jobs.Select(MapToResponse);
    }

    public async Task<JobResponseDto?> UpdateAsync(
        Guid jobId,
        UpdateJobDto dto,
        Guid companyId)
    {
        var job = await _jobRepository .GetByIdAndCompanyIdAsync(jobId, companyId); 
        if (job == null)
            return null;
        job.JobTitle = dto.JobTitle;
        job.Description = dto.Description; 
        job.Experience = dto.Experience;
        job.JobType = dto.JobType;
        await _jobRepository.UpdateAsync(job); 
        return MapToResponse(job);
    }

    public async Task<bool> DeleteAsync(
        Guid jobId,
        Guid companyId)
    {
        var job = await _jobRepository .GetByIdAndCompanyIdAsync(jobId, companyId); 
        if (job == null) 
            return false; 
        await _jobRepository.DeleteAsync(job); 
        return true;
    }

    private static JobResponseDto MapToResponse(Job job)
    {
        return new JobResponseDto
        {
            JobId = job.JobId,
            JobTitle = job.JobTitle,
            Description = job.Description, 
            Experience = job.Experience, 
            CompId = job.CompId, 
            JobType = job.JobType, 
            CreatedAt = job.CreatedAt
        };
    }
}