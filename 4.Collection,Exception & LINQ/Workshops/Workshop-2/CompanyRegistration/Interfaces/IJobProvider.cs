

using CompanyMember.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMember.Interfaces
{
    public interface IJobProvider
    {
        void PostJob(Job job);
        List<Job> GetJobs();
    
    }
}
