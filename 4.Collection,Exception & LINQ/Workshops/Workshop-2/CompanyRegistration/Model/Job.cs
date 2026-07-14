using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Admin_Job.Enums.ExperienceLevel;

namespace CompanyMember.Model
{
    public class Job
    {
		private string description;
		private string type;
		private string salary;

		public Job(string title, string description, string location, string type, string salary, string company)
		{
			Title = title;
			this.description = description;
			Location = location;
			this.type = type;
			this.salary = salary;
			Company = company;
		}

		public int Id { get; set; }
        public string Title { get; set; }
        public ExperienceLevels ExperienceLevel { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string SalaryRange { get; set; }
        public string JobType { get; set; }
    }
        }
    

