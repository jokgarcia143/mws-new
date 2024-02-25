using Microsoft.AspNetCore.Mvc;
using MWS.Web.Models;
using System;
using System.Composition;
using System.Linq;

namespace MWS.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly MWSWebDBContext _context;

        public DashboardController(MWSWebDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DateTime dateTimeObject = DateTime.Now;

            // Extract month, date, and year
            int month = dateTimeObject.Month;
            int day = dateTimeObject.Day;
            int year = dateTimeObject.Year;

            // Pass the values to ViewData
            ViewData["Date"] = DateTime.Now.ToShortDateString();

            //CONSUMERS
            var startDate = Convert.ToDateTime("01-" + "01" + "-" + year);
            var endDate = DateTime.Now;
            var customerList =  _context.CustomersSummaries.Where(c => c.PresDate2 >= startDate && c.PresDate2 <= endDate).ToList();


            var _consumers = _context.Customers.Where(c => c.AcctNo != string.Empty);
            var residential = _context.Customers.Count(c => c.AcctType == "Residential");
            var commercial = _context.Customers.Count(c => c.AcctType == "Commercial");
            var govt = _context.Customers.Count(c => c.AcctType == "Government");

            ViewData["Consumers"] = _consumers.Count();
            ViewData["New"] = customerList.Where(c => c.Type == "NEW CONNECTION").Count();
            ViewData["Open"] = _consumers.Where(c => c.Status == "Open").Count();
            ViewData["Closed"] = _consumers.Where(c => c.Status == "Closed").Count();
            ViewData["T-Closed"] = _consumers.Where(c => c.Status == "T-Closed").Count();

            ViewData["Residential"] = residential;
            ViewData["Commercial"] = commercial;
            ViewData["Government"] = govt;

            //var payments = _context.CustomersSummaries.Where(c => c.DatePaid2 >= startDate && c.DatePaid2 <= endDate && c.Type=="PAYMENT").ToList();
            var payments = _context.CustomersSummaries.Where(c => c.Type == "PAYMENT").ToList();
            ViewData["Paid"] = payments.Sum(c => c.AmountPaid2).ToString("C2", new System.Globalization.CultureInfo("en-PH"));

            return View();
        }
    }
}
