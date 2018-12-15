using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(double txtval1, double txtval2,
                   string add, string substract)
        {
            if (!string.IsNullOrEmpty(add))
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress addr = new EndpointAddress("http://localhost/WcfServiceCalculator/Calculator.svc");
                var client = new ServiceReference2.CalculatorClient(binding, addr);
                ViewBag.Message = "Result-Add: " + client.Add(txtval1, txtval2);
                return View();

            }
            if (!string.IsNullOrEmpty(substract))
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress addr = new EndpointAddress("http://localhost/WcfServiceCalculator/Calculator.svc");
                var client = new ServiceReference2.CalculatorClient(binding, addr);
                ViewBag.Message = "Result-Substract: " + client.Subtract(txtval1, txtval2);
                return View();
            }
            return View();
        }
    }
}