using Jobportal.Models;

namespace Jobportal.Manage;

public class InterviewManage
{
    public Interview[] interviews = new Interview[100];
    int interviewCount = 0;
    public void addInterview()
    {
        Console.WriteLine("Adding interview");
        Console.WriteLine("Enter Interview ID:");
        int interviewId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Interview Name:");
        string interviewName = Console.ReadLine();
        Console.WriteLine("Enter Interview Description:");
        string interviewDescription = Console.ReadLine();
        
    }
}