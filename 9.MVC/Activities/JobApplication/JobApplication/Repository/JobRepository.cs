using JobApplication.Data;
using JobApplication.Interfaces.Repository;
using JobApplication.Interfaces.Services;
using JobApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.Repository;

public class JobRepository: IJobRepository
{
    private readonly MyDbContext context;
    public JobRepository(MyDbContext context)
    {
        this.context = context;
    }

    public async Task<Job> AddAsync(Job job)
    {
        await context.Jobs.AddAsync(job);
        await context.SaveChangesAsync();
        return job;
    }

    public async Task<Job?> GetByIdAsync(Guid jobId)
    {
        return await context.Jobs.AsNoTracking().FirstOrDefaultAsync(x => x.JobId == jobId);
    }

    public async Task<IEnumerable<Job>> GetAllAsync()
    {
        return await context.Jobs.AsNoTracking().OrderByDescending(x => x.CreatedAt).ToListAsync();
    }

    public async Task<IEnumerable<Job>> GetByCompanyIdAsync(Guid companyId)
    {
        return await context.Jobs.AsNoTracking().Where(x=>x.CompId == companyId).OrderByDescending(x => x.CreatedAt).ToListAsync();
    }

    public async Task<Job?> GetByIdAndCompanyIdAsync(
        Guid jobId,
        Guid companyId)
    {
        return await context.Jobs .FirstOrDefaultAsync(x => x.JobId == jobId && x.CompId == companyId);
    }

    public async Task UpdateAsync(Job job)
    {
        context.Jobs.Update(job);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Job job)
    {
        context.Jobs.Remove(job); 
        await context.SaveChangesAsync();
    }

    public async  Task<bool> ExistsAsync(Guid jobId)
    {
        return await context.Jobs .AnyAsync(x => x.JobId == jobId);
    }
}