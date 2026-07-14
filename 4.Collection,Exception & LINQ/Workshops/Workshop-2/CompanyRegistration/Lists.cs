
using CompanyMember.Model;
using CompanyMember.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMember
{
    public class Lists
    {
       
          
        public void Print(List<Company> companies)
        {
            Console.WriteLine("Companies : \n");
            Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |  {5,-20} |  {6,-20} |  {7,-20} |  {8,-20}  ", "Name", "Email", "website", "phone", "about", "vision", "mission", "location", "address");
            
            if (companies != null)
                foreach (Company company in companies)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");

                    Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |  {5,-20} |  {6,-20} |  {7,-20} |   {8,-20} |  ", company.Name,company.Email,company.Website,company.Phone,company.About,company.Vision,company.Mission,company.Location,company.Address);
                }

            Console.WriteLine("\n");

        }
		public void Print(List<Job> jobs)
		{
			Console.WriteLine("Jobs available: \n");
			Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |  {5,-20} |  {6,-20}   ", "JobId", "Title", "ExperienceLevel", "Company", "Location", "SalaryRange", "JobType");
			
			foreach (Job job in jobs)
			{
				Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

				Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |  {5,-20} |  {6,-20}   ", job.Id, job.Title, job.ExperienceLevel, job.Company, job.Location, job.SalaryRange, job.JobType);
			}

			Console.WriteLine("\n");
		}

	}
}

