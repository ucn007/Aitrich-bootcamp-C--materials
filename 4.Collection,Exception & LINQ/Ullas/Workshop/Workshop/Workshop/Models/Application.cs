namespace WorkShop.Models;

public class Application
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public int UserId { get; set; }
    public string JobTitle { get; set; }
    public string applicantName { get; set; }
    public string applicantEmail { get; set; } 
    public string CompanyName { get; set; }

    public Application(int id, int jobId, int userId, string jobTitle, string applicantName, string applicantEmail,
        string companyName)
    {
        Id = id;
        JobId = jobId;
        UserId = userId;
        JobTitle = jobTitle;
        this.applicantName = applicantName;
        this.applicantEmail = applicantEmail;
        this.CompanyName = companyName;
            
        
    }
    
}