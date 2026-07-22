 

 

using WorkShop.Interface;
using WorkShop.Models;

namespace WorkShop.Repository;

public class JobRepository: IJobinterface
{
    private readonly List<Job> jobs = new List<Job>();

    public void Add(Job job)
    {
        jobs.Add(job);
    }

    public List<Job> GetAll()
    {
        return jobs;
    }

    public Job GetById(int id)
    {
        return jobs.FirstOrDefault(j => j.Id == id);
    }

    public void Delete(int id)
    {
        var job = GetById(id);

        if (job != null)
        {
            jobs.Remove(job);
        }
    }
}