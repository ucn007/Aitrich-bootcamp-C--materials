using CompanyMember.Interfaces;
using CompanyMember.Model;
using JobSeeker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Admin_Job.Enums.ExperienceLevel;

namespace CompanyMember.Repository
{
    public class JobRepository : IJobRepository
    {
        public JobRepository()
        {

        }
        List<Job> jobs = new List<Job>();
        
        public List<Job> GetAllJobs()
        {
            return jobs;
        }
    }
}
