using JobSeeker.Interfaces;
using JobSeeker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Admin_Job.Enums.ExperienceLevel;

namespace JobSeeker.Repository
{
    public class JobRepository : IJobRepository
    {
        public JobRepository()
        {

        }
        List<Job> jobs = new List<Job>()
        {
            new Job { Id = 1, Title = "Software Engineer", ExperienceLevel = ExperienceLevels.Senior, Company = "Acme Inc.", Location = "New York, NY", SalaryRange = "$100,000 - $150,000",JobType="Full Time" },
            new Job { Id = 2, Title = "Product Manager", ExperienceLevel = ExperienceLevels.MidLevel, Company = "Globex Corp.", Location = "San Francisco, CA", SalaryRange = "$120,000 - $180,000", JobType="Part Time" },
            new Job { Id = 3, Title = "Marketing Specialist", ExperienceLevel = ExperienceLevels.Fresher, Company = "Hooli Enterprises", Location = "Seattle, WA", SalaryRange = "$70,000 - $90,000",JobType="Intern" }
        };
        public List<Job> GetAllJobs()
        {
            return jobs;
        }
    }
}
