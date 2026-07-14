using Jobportal.Models;

namespace Jobportal.Manage;

public class ApplicationManage
{
    Job[] jobs = new Job[100];
    Application[] applications = new Application[100];

    int jobCount = 0;
    int applicationCount = 0;
    
    public void ApplyJob(Job[] jobs, int jobCount,
        Application[] applications,
        ref int applicationCount,
        int seekerId)
    {
        Console.Write("Enter Job Id: ");
        int jobId = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = 0; i < jobCount; i++)
        {
            if (jobs[i].id == jobId)
            {
                found = true;

                // Check whether already applied
                for (int j = 0; j < applicationCount; j++)
                {
                    if (applications[j].JobId == jobId &&
                        applications[j].SeekerId == seekerId)
                    {
                        Console.WriteLine("You have already applied.");
                        return;
                    }
                }

                applications[applicationCount++] =
                    new Application(applicationCount, jobId, seekerId);

                Console.WriteLine("Application submitted successfully.");
                return;
            }
        }

        if (!found)
        {
            Console.WriteLine("Job not found.");
        }
    }
    
    
    public void ViewAppliedJobs(Job[] jobs,
        Application[] applications,
        int applicationCount,
        int seekerId)
    {
        Console.WriteLine("Applied Jobs");

        for (int i = 0; i < applicationCount; i++)
        {
            if (applications[i].SeekerId == seekerId)
            {
                for (int j = 0; j < jobs.Length; j++)
                {
                    if (jobs[j] != null &&
                        jobs[j].id == applications[i].JobId)
                    {
                        Console.WriteLine($"{jobs[j].id} - {jobs[j].name}");
                    }
                }
            }
        }
    }
    
}