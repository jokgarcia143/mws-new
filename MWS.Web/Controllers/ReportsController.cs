using Aspose.Pdf.Operators;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using MWS.Web.Interfaces;
using MWS.Web.Models;
using MWS.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace MWS.Web.Controllers
{
    [Authorize(Roles = "Administrator,Staff")]
    public class ReportsController : Controller
    {
        private readonly MWSWebDBContext _context;
        private readonly IDocumentService _documentService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConverter _converter;
        private readonly IEnumerable<Barangay> _barangays;
        private readonly IEnumerable<string> _statuses;
        private readonly IEnumerable<string> _accountTypes;

        public ReportsController(MWSWebDBContext context, IDocumentService documentService, IWebHostEnvironment environment, IConverter converter)
        {
            _converter = converter;
            _context = context;
            _documentService = documentService;
            _webHostEnvironment = environment;
            _barangays = _context.Barangays.Distinct().AsEnumerable();
            _statuses = _context.Customers.Where(c => c.Status == "Closed" || c.Status == "T-Closed").Select(s => s.Status).Distinct().AsEnumerable();
            _accountTypes = _context.Customers.Select(s => s.AcctType).Distinct().AsEnumerable();
        }

        #region "General Reports"
        public IActionResult Index()
        {
            // Populate a list of months with key-value pairs
            List<SelectListItem> months = new List<SelectListItem>
        {
            new SelectListItem { Value = "01", Text = "January" },
            new SelectListItem { Value = "02", Text = "February" },
            new SelectListItem { Value = "03", Text = "March" },
            new SelectListItem { Value = "04", Text = "April" },
            new SelectListItem { Value = "05", Text = "May" },
            new SelectListItem { Value = "06", Text = "June" },
            new SelectListItem { Value = "07", Text = "July" },
            new SelectListItem { Value = "08", Text = "August" },
            new SelectListItem { Value = "09", Text = "September" },
            new SelectListItem { Value = "10", Text = "October" },
            new SelectListItem { Value = "11", Text = "November" },
            new SelectListItem { Value = "12", Text = "December" }
        };

            // Store the list of months in ViewBag
            ViewBag.Months = new SelectList(months, "Value", "Text");

            int year = DateTime.Now.Year;
            List<int> years = new();
            for (int i = year; i > 2000; i--)
            {
                years.Add(i);
            }
        
            ViewBag.Years = from selectYear in years orderby selectYear ascending select selectYear;
        
            ReportsViewModel reportsVM = new()
            {
                Barangays = _barangays.OrderBy(b => b.Brgy),
                Statuses = _statuses,
                AccountTypes = _accountTypes
            };
            return View(reportsVM);
        }
        /// <summary>
        /// Meter Reading Report
        /// PDF Printing OK
        /// </summary>
        /// <param name="BarangayId"></param>
        /// <returns></returns>
        public async Task<IActionResult> MeterReadingReportPDF(int BarangayId)
        {
            var barangay = _barangays.FirstOrDefault(b => b.BrgyId == BarangayId);
            var customers = await _context.Customers.Where(cs => cs.Barangay == barangay.Brgy).ToListAsync();
            var customerWaterBillSummaries = _context.CustomersSummaries.Where(c => c.Type == "WATER BILL ISSUE");
            var customerMeterReadings = new List<MeterReadingReports>();

            foreach (var customer in customers)
            {
                var customerWaterBillSummary = customerWaterBillSummaries.Where(c => c.AcctNo == customer.AcctNo).OrderBy(cs => cs.Name).LastOrDefault();
                if (customerWaterBillSummary != null)
                {
                    var customerMeterReading = new MeterReadingReports
                    {
                        Name = customerWaterBillSummary.Name,
                        AcctNo = customerWaterBillSummary.AcctNo,
                        MeterNo = customerWaterBillSummary.MeterNo,
                        InitialReading = customerWaterBillSummary.Reading,
                        Status = (customer.Status == "T-Closed" || customer.Status == "Closed") ? customer.Status : String.Empty
                    };

                    customerMeterReadings.Add(customerMeterReading);
                }
            }

            if (customerMeterReadings != null)
            {
                var customerReadingReportsViewModel = new MeterReadingReportsViewModel
                {
                    CustomerMeterReadings = customerMeterReadings,
                    Barangay = barangay.Brgy
                };
                return View(customerReadingReportsViewModel);
            }

            return View(new MeterReadingReportsViewModel());
        }
        /// <summary>
        /// Water Bill Batch Printing
        /// PDF Printing OK
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        public async Task<IActionResult> ReprintBatchWaterBillPDF(ReportsViewModel report)
        {
            //var startDate = Convert.ToDateTime("01/" + report.MonthId + "/" + report.SelectedYear);
            var startDate = Convert.ToDateTime(report.MonthId + "-01-" + report.SelectedYear);
            var endDate = DateTime.Now;

            var selectedBrgy = _context.Barangays.Where(c => c.BrgyId == Convert.ToInt32(report.SelectedBrgy)).Select(x => x.Brgy).FirstOrDefault();

            if (report.MonthId == "01" || report.MonthId == "03" || report.MonthId == "05" || report.MonthId == "08" || report.MonthId == "10" || report.MonthId == "12")
            {
                //endDate = Convert.ToDateTime("31/" + report.MonthId + "/" + report.SelectedYear);
                endDate = Convert.ToDateTime(report.MonthId + "-31-" + report.SelectedYear);
            }
            else if (report.MonthId == "02")
            {
                //endDate = Convert.ToDateTime("29/" + report.MonthId + "/" + report.SelectedYear);
                endDate = Convert.ToDateTime(report.MonthId + "-29-" + report.SelectedYear);
            }
            else
            {
                //endDate = Convert.ToDateTime("30/" + report.MonthId + "/" + report.SelectedYear);
                endDate = Convert.ToDateTime(report.MonthId + "-30-" + report.SelectedYear);
            }
            
            var customerList = await _context.CustomersSummaries.Where(c => c.Barangay == selectedBrgy && c.PresDate != "NA" && (c.PresDate2 >= startDate && c.PresDate2 <= endDate)).Take(50).ToListAsync();

            return View(customerList);
        }
        /// <summary>
        /// Closed and Open Accounts
        /// PDF Printing NOT OK
        /// </summary>
        /// <param name="BarangayId"></param>
        /// <returns></returns>
        public async Task<IActionResult> ClosedConsumersReportPDF(int BarangayId)
        {
            var barangay = _barangays.FirstOrDefault(b => b.BrgyId == BarangayId);
            var customers = await _context.Customers.Where(cs => cs.Barangay == barangay.Brgy && (cs.Status == "T-Closed" || cs.Status == "Closed")).ToListAsync();
            var closedConsumers = new ClosedConsumersReportsViewModel();
            if (customers != null)
            {
                closedConsumers.Consumers = customers;
                closedConsumers.Barangay = barangay.Brgy;

                return View(closedConsumers);
            }
            return View(new ClosedConsumersReportsViewModel());
        }
        /// <summary>
        /// New Connections
        /// PDF Printing NOT OK
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> NewConnectionsReportPDF(ReportsViewModel report) 
        {
            var startDate = Convert.ToDateTime("01" + "-01-" + report.SelectedYear);
            var endDate = DateTime.Now;


            var newConnections = new List<NewConnectionsVM>();
            //TOTALS
            int residential_t = 0;
            int commercial_t = 0;
            int govt_t = 0;

            var baranggays = await _context.Barangays.ToListAsync();
            
            foreach(var brgy in baranggays)
            {
                var residential = _context.Customers.Count(c => c.Barangay == brgy.Brgy && c.AcctType=="Residential");
                var commercial = _context.Customers.Count(c => c.Barangay == brgy.Brgy && c.AcctType == "Commercial");
                var govt = _context.Customers.Count(c => c.Barangay == brgy.Brgy && c.AcctType == "Government");

                //var commercial = _context.Customers.Count(c => c.Barangay == brgy.Brgy && c.AcctType == "Commercial");
                //var govt = _context.Customers.Count(c => c.Barangay == brgy.Brgy && c.AcctType == "Government");
                                            
                newConnections.Add(new NewConnectionsVM()
                {
                    Baranggay = brgy.Brgy.ToString(),
                    Residential = residential,
                    Commercial = commercial,
                    Government = govt
                });

                residential_t = residential_t + residential;
                
            }

            residential_t = newConnections.Sum(c => c.Residential);
            commercial_t = newConnections.Sum(c => c.Commercial);
            govt_t = newConnections.Sum(c => c.Government);

            TempData["Residential"] = residential_t;
            TempData["Commercial"] = commercial_t;
            TempData["Government"] = govt_t;

            return View(newConnections.OrderBy(c => c.Baranggay));
        }
        /// <summary>
        /// Number of Connections
        /// PDF Printing NOT OK
        /// </summary>
        /// <returns></returns>
        public IActionResult NumberOfConnectionsReportPDF()
        {
            var barangays = _barangays.OrderBy(c => c.Brgy);
            var numberOfConnections = new List<NumberOfConnection>();

            foreach (var barangay in barangays)
            {
                var numberOfConnection = new NumberOfConnection();
                numberOfConnection.Barangay = barangay.Brgy;
                numberOfConnection.Residential = _context.Customers.Count(c => c.AcctType == "Residential" && c.Barangay == barangay.Brgy);
                numberOfConnection.Commercial = _context.Customers.Count(c => c.AcctType == "Commercial" && c.Barangay == barangay.Brgy);
                numberOfConnection.Government = _context.Customers.Count(c => c.AcctType == "Government" && c.Barangay == barangay.Brgy);
                numberOfConnections.Add(numberOfConnection);
            }

            return View(numberOfConnections);
        }
        #endregion

        #region "Cubic Consumed"
        /// <summary>
        /// Reprint Cubic Consumed
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        public async Task<IActionResult> ReprintCubicConsumedPerBrgyPDF(ReportsViewModel report)
        {
            //FIELDS: Name, Account Type, Account No, Meter No, Cubic Consumed
            //var startDate = Convert.ToDateTime("01/" + report.MonthIdCubicBrgy + "/" + report.YearIdCubicBrgy);
            var startDate = Convert.ToDateTime(report.MonthIdCubicBrgy + "-01-" + report.YearIdCubicBrgy);
            var endDate = startDate;

            var selectedBrgy = _context.Barangays.Where(c => c.BrgyId == Convert.ToInt32(report.CubicBarangayId)).Select(x => x.Brgy).FirstOrDefault();

            if (report.MonthIdCubicBrgy == "01" || report.MonthIdCubicBrgy == "03" || report.MonthIdCubicBrgy == "05" || report.MonthIdCubicBrgy == "08" || report.MonthIdCubicBrgy == "10" || report.MonthIdCubicBrgy == "12")
            {
                //endDate = Convert.ToDateTime("31/" + report.MonthIdCubicBrgy + "/" + report.YearIdCubicBrgy);
                endDate = Convert.ToDateTime(report.MonthIdCubicBrgy + "-31-" + report.YearIdCubicBrgy);
            }
            else if (report.MonthId == "02")
            {
                //endDate = Convert.ToDateTime("29/" + report.MonthIdCubicBrgy + "/" + report.YearIdCubicBrgy);
                endDate = Convert.ToDateTime(report.MonthIdCubicBrgy + "-29-" + report.YearIdCubicBrgy);
            }
            else
            {
                endDate = Convert.ToDateTime(report.MonthIdCubicBrgy + "-30-" + report.YearIdCubicBrgy);
            }

            var customerList = await _context.CustomersSummaries.Where(c => c.Barangay == selectedBrgy && c.PresDate != "NA" && (c.PresDate2 >= startDate && c.PresDate2 <= endDate)).Take(50).ToListAsync();

            return View(customerList);
        }
        /// <summary>
        /// Monthly Billed Accounts
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<IActionResult> MonthlyBilledAccountsPerBarangayAccountTypePDF(ReportParameters parameters)
        {
            var consumers = await _context.CustomersSummaries.Where(cs => cs.Barangay == parameters.Barangay && cs.Month == String.Format("{0} / {1}", parameters.Month, parameters.Year) && cs.Type == parameters.AccountType).ToListAsync();
            if (consumers != null)
            {
                return View(consumers);
            }

            return NotFound();
        }
        #endregion
        
        private static List<SelectListItem> PopulateMonths()
        {
            var months = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "January" },
                new SelectListItem { Value = "2", Text = "February" },
                new SelectListItem { Value = "3", Text = "March" },
                new SelectListItem { Value = "4", Text = "April" },
                new SelectListItem { Value = "5", Text = "May" },
                new SelectListItem { Value = "6", Text = "June" },
                new SelectListItem { Value = "7", Text = "July" },
                new SelectListItem { Value = "8", Text = "August" },
                new SelectListItem { Value = "9", Text = "September" },
                new SelectListItem { Value = "10", Text = "October" },
                new SelectListItem { Value = "11", Text = "November" },
                new SelectListItem { Value = "12", Text = "December" }
            };

            return months;
        }
        public async Task<IActionResult> CubicConsumedPerBarangayPDF()
        {
            var cubicConsumedPerBarangayPDF = await _context.TmpCcs.ToListAsync();
            return View(cubicConsumedPerBarangayPDF);
        }
        
        
    }
}
