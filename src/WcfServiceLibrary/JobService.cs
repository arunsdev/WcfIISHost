using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class JobService : IJobService
    {
        private List<Jobs> jobs = new List<Jobs>() { new Jobs() { JobName = "Job1", Role = "Role1" }
        ,new Jobs() { JobName = "Job2", Role = "Role1" }
        ,new Jobs() { JobName = "Job3", Role = "Role2" }
        ,new Jobs() { JobName = "Job4", Role = "Role2" }
        ,new Jobs() { JobName = "Job5", Role = "Role3" }};
        public List<Jobs> OpeningJobs()
        {
            return jobs;
        }

        public List<Jobs> OpeningJobsByRole(string role)
        {
            return jobs.Where(j => j.Role == role).ToList();
        }
    }
}
