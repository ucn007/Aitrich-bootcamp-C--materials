using CompanyMember.Interfaces;
using CompanyMember.Model;
using CompanyMember.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMember.Manager
{
	public class JobManager : IMenu
	{
		IJobProvider Jobs = new JobPortal();
		private User loggedUser;
		Lists list = new Lists();
		public JobManager(User loggedUser)
		{
			this.loggedUser = loggedUser;
		}
		public void DisplayMenu()
		{
			ShowProviderMenu();
		}
		private void ShowProviderMenu()
		{
			Console.WriteLine("1. Post a  job ");
			Console.WriteLine("2. List all Jobs ");
			Console.WriteLine("3. Logout");

			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					Console.Write("Enter Job title: ");
					string title = Console.ReadLine();
					Console.Write("Enter Job description: ");
					string description = Console.ReadLine();
					Console.Write("Enter Job location: ");
					string location = Console.ReadLine();
					Console.Write("Enter Job Type: ");
					string type = Console.ReadLine();
					Console.Write("Enter Job salary range: ");
					string salary = (Console.ReadLine());
					Console.Write("Enter Job company: ");
					string company = (Console.ReadLine());
					Job job = new Job(title, description, location, type, salary, company);
					Jobs.PostJob(job);
					Console.WriteLine("Job posted successfully.");
					ShowProviderMenu();
					break;
				case "2":
					List<Job> jobs = Jobs.GetJobs();
					list.Print(jobs);
					ShowProviderMenu();
					break;
				case "3":
					Logout();
					break;
				default:
					Console.WriteLine("Invalid choice. Please try again.");
					ShowProviderMenu();
					break;
			}
		}
		public void Logout()
		{
			loggedUser = new User();
			Console.WriteLine("Logged out successfully!");

		}
	}

        
}
