using JobApplication.Models;

namespace JobApplication.Interfaces.Repository;

public interface IJobRepository
{
    Task<Job> AddAsync(Job job);

    Task<Job?> GetByIdAsync(Guid jobId);

    Task<IEnumerable<Job>> GetAllAsync();

    Task<IEnumerable<Job>> GetByCompanyIdAsync(Guid companyId);

    Task<Job?> GetByIdAndCompanyIdAsync(
        Guid jobId,
        Guid companyId);

    Task UpdateAsync(Job job);

    Task DeleteAsync(Job job);

    Task<bool> ExistsAsync(Guid jobId);
}