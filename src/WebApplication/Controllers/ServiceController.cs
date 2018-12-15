using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtname,
                   string getjobs, string jobybyrole)
        {

            if (!string.IsNullOrEmpty(getjobs))
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress addr = new EndpointAddress("http://localhost/WcfService/JobService.svc/");
                var client = new ServiceReference1.JobServiceClient(binding, addr);
                var jobs = new List<Jobs>();
                foreach (var item in client.OpeningJobs())
                {
                    jobs.Add(new Jobs()
                    {
                        JobName = item.JobName,
                        Role = item.Role
                    });
                }
                return View("JobsResult", jobs);

            }
            if (!string.IsNullOrEmpty(jobybyrole))
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress addr = new EndpointAddress("http://localhost/WcfService/JobService.svc/");
                var client = new ServiceReference1.JobServiceClient(binding, addr);
                var jobs = new List<Jobs>();
                foreach (var item in client.OpeningJobsByRole(txtname))
                {
                    jobs.Add(new Jobs()
                    {
                        JobName = item.JobName,
                        Role = item.Role
                    });
                }
                return View("JobsResult", jobs);
            }
            return View();
        }
    }
}