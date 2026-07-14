namespace Jobportal.Models;

public class Interview
{
    public int interviewId { get; set; }
    public string JobId { get; set; }
    public string ApplicationId { get; set; } 
    public string interviewDate { get; set; }
    public string interviewVenue { get; set; }

    public void Inverview(int interviewId, string jobId, string applicationId, string interviewDate, string interviewVenue)
    {
        this.interviewId = interviewId;
        this.JobId = jobId;
        this.ApplicationId = applicationId;
        this.interviewDate = interviewDate;
        this.interviewVenue = interviewVenue;
            
    }
}