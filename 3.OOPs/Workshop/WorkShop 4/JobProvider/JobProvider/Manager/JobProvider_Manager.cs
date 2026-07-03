using JobProvider.Interface;
using JobProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProvider.Manager
{
   
    public class JobProvider_Manager:IUserRepository,IjobRepository
    {

        JobProvider.Model.JobProvider provid = new JobProvider.Model.JobProvider();
        Job job= new Job();
        private const int Max_JProvider = 10;
        private const int Max_jobs = 100;
        public Model.JobProvider[] Provider = new Model.JobProvider[Max_JProvider];
        private int numProvider = 0;
      

        private Job[] jobs = new Job[Max_jobs];
        private int numJobs = 0;
        int id = 0;
        public void Register()

        {


            if (numProvider == Max_JProvider)
            {
                Console.WriteLine("Maximum number of Providers reached. Please try again later.");
                return;
            }
     
           provid.Id= id;
            id++;
           
            Console.Write("Enter firstname: ");
            string firstname = Console.ReadLine();
            Console.Write("Enter lastname: ");
            string lastname = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter designation: ");
            string designation= Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // Check if username is already taken
            for (int i = 0; i < numProvider; i++)
            {
                if (Provider[i].Email == email)
                {
                    Console.WriteLine("Username already taken. Please choose another username.");
                    return;
                }
            }

            // Add provider to array
            Provider[numProvider] = new Model.JobProvider(id, firstname, lastname, email, designation, password);
          numProvider=numProvider++;

            Console.WriteLine("Registration successful. Please log in to continue.");
        }

        public void Login()
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.WriteLine(numProvider);
            // Check if username and password match
            for (int i = 0; i < Provider.Length; i++)
            {
                if (Provider[i].Email == email && Provider[i].Password == password)
                {
                    string input = "0";
                    while (input != "3"){
                        Console.WriteLine("Login successful!");
                        Console.WriteLine("1. Add Job");
                        Console.WriteLine("2. List Jobs");
                        Console.WriteLine("3. Back to main");
                        input = Console.ReadLine();

                        if (input == "1")
                        {
                            AddJob();
                        }
                        else if (input == "2")
                        {
                            ListJob();
                        }
                        else if (input == "3")
                        {
                            Console.Write("Back to menu");
                        }
                        else
                        {
                            Console.WriteLine("invalid choice");
                        } }
                        return;
                }
            }

            Console.WriteLine("Invalid username or password. Please try again.");
        }
     
        public void AddJob()
        {
            if (numJobs == Max_jobs)
            {
                Console.WriteLine("Maximum number of jobs reached. Please try again later.");
                return;
            }
            
            job.id = id;
            id++;
            Console.Write("Enter job title: ");
            string title = Console.ReadLine();

            Console.Write("Enter job description: ");
            string description = Console.ReadLine();
            Console.Write("Enter job salary: ");
            string salary = Console.ReadLine();
            Console.Write("Enter job location: ");
            string location = Console.ReadLine();
            Job newJob = new Job(id,title, description,salary,location);
            //ijobRepository.AddJob(newJob);

            jobs[numJobs] = newJob;
            numJobs++;

         

            Console.WriteLine("Job added successfully.");
        }
        public void ListJob()
        {
            Console.WriteLine("Jobs:");
            for (int i = 0; i < numJobs; i++)
            {
                Console.WriteLine($"id: {jobs[i].id}");
                Console.WriteLine($"Title: {jobs[i].title}");
                Console.WriteLine($"Description: {jobs[i].description}");
                Console.WriteLine($"salary: {jobs[i].salary}");
                Console.WriteLine($"Location: {jobs[i].Location}");
            }
        }

  
        //public void ListJob()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
