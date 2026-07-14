namespace Jobportal.Models;

 
    public class Application
    {
        public int ApplicationId { get; set; }
        public int JobId { get; set; }
        public int SeekerId { get; set; }

        public Application(int applicationId, int jobId, int seekerId)
        {
            ApplicationId = applicationId;
            JobId = jobId;
            SeekerId = seekerId;
        }
    }
