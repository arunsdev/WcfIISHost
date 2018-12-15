using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class JobService : IJobService
    {
        private IEnumerable<Jobs> jobs = new List<Jobs>() { new Jobs() { JobName = "Job1", Role = "Role1" }
        ,new Jobs() { JobName = "Job2", Role = "Role1" }
        ,new Jobs() { JobName = "Job3", Role = "Role2" }
        ,new Jobs() { JobName = "Job4", Role = "Role2" }
        ,new Jobs() { JobName = "Job5", Role = "Role3" }};
        public IEnumerable<Jobs> OpeningJobs()
        {
            return jobs;
        }

        public IEnumerable<Jobs> OpeningJobsByRole(string role)
        {
            return jobs.Where(j => j.Role == role);
        }
    }
}
