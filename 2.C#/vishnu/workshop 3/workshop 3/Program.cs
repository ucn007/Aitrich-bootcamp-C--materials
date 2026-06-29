internal class Program
{


    struct job
    {
        public string title;
        public string description;
        public double salary;
        public string location;
    }
    private static void Main(string[] args)
    {
        job[] jobs = new job[10];
        int jobcount = 0;

        string choice;
        do {
            Console.WriteLine("Job provider");
            Console.WriteLine("A- Post a job");
            Console.WriteLine("D- Display Posted jobs");
            Console.WriteLine("Select an option");
            string command = Console.ReadLine()?.Trim().ToUpper();
            switch (command)
            {
                case "A":
                    Console.WriteLine("How many jobs do you want post?");
                    int count = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < count && jobcount < jobs.Length; i++)
                    {
                        Console.WriteLine("Job details");
                        Console.WriteLine($"Enter the name of the job {jobcount + 1}");
                        jobs[jobcount].title = Console.ReadLine();
                        Console.WriteLine("Enter the description of the job");
                        jobs[jobcount].description = Console.ReadLine();
                        Console.WriteLine("Enter the salary of the job");
                        jobs[jobcount].salary = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the location of the job");
                        jobs[jobcount].location = Console.ReadLine();
                        jobcount++;
                    }
                    break;

                case "D":
                    Console.WriteLine("List of jobs");
                    if (jobcount == 0)
                    {
                        Console.WriteLine("No jobs posted");
                    }
                    else
                    {
                        for (int i = 0; i < jobcount; i++)
                        {
                            Console.WriteLine($"Job ID {i + 1}");
                            Console.WriteLine($"Name of job {jobs[i].title}");

                            Console.WriteLine($"Description {jobs[i].description}");

                            Console.WriteLine($"Salary {jobs[i].salary}");

                            Console.WriteLine($"Location {jobs[i].location}");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
            Console.WriteLine("Do you want continue (Yes/No)");
            choice = Console.ReadLine()?.Trim().ToLower();
        }
        while (choice == "yes");

    













                    }
}