using JobSeeker.Model;
using JobSeeker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.Manager
{
    public class JobManager
    {
        JobRepository jobRepository = new JobRepository();

        public void ListJobs()
        {
            Console.WriteLine("Jobs available: \n");
            Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |  {5,-20} |  {6,-20}   ", "JobId", "Title", "ExperienceLevel", "Company", "Location", "SalaryRange", "JobType");
            List<Job> jobs = jobRepository.GetAllJobs();
            foreach (Job job in jobs)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |  {5,-20} |  {6,-20}   ", job.Id, job.Title, job.ExperienceLevel, job.Company, job.Location, job.SalaryRange, job.JobType);
            }

            Console.WriteLine("\n");
        }

    }
}
