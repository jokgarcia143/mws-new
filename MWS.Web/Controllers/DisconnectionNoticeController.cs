using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Web.Interfaces;
using MWS.Web.Models;
using MWS.Web.Utilities;
using System.Threading.Tasks;
using MWS.Web.Services;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.IO;
using SelectPdf;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MWS.Web.Controllers
{
    [Authorize(Roles = "Administrator,Staff")]
    public class DisconnectionNoticeController : Controller
    {
        private readonly MWSWebDBContext _context;
        private readonly IDocumentService _documentService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConverter _converter;
        private readonly IEnumerable<Barangay> _barangays;

        public DisconnectionNoticeController(MWSWebDBContext context, IDocumentService documentService, IWebHostEnvironment environment, IConverter converter)
        {
            _converter = converter;
            _context = context;
            _documentService = documentService;
            _webHostEnvironment = environment;
            _barangays = _context.Barangays.Distinct().AsEnumerable().OrderBy(c => c.Brgy);
        }

        public IActionResult Index()
        {
            TempData["BrgyId"] = "0";
            DisconnectionNoticeViewModel disconnectionNoticeVM = new()
            {
                Barangays = _barangays,
                Disconnections = new List<Disconnection>()
            };

            return View(disconnectionNoticeVM);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int barangayId)
        {
            TempData["BrgyId"] = barangayId;
            var barangay = _barangays.Where(b => b.BrgyId == barangayId).FirstOrDefault().Brgy;
            var customersSummaries = await _context.CustomersSummaries.Where(d => d.Barangay == barangay).ToListAsync();
            var customers = await _context.Customers.Where(c => c.Barangay == barangay).ToListAsync();
            var lastTransactionNo = _context.Disconnections.Count();
            var disconnections = new List<Disconnection>();

            foreach (var customer in customers)
            {
                var latestRecord = customersSummaries.Where(c => c.AcctNo == customer.AcctNo).OrderBy(cs => cs.Id).LastOrDefault();
                if (latestRecord != null)
                {
                    if (Convert.ToDouble(latestRecord.Balance) > 0 && latestRecord.DueDate != "NA")
                    {
                        //string[] dueDateRaw = latestRecord.DueDate2.Split('/');
                        //var dueDate = new DateTime(Convert.ToInt32(dueDateRaw[2]), Convert.ToInt32(dueDateRaw[0]), Convert.ToInt32(dueDateRaw[1]));
                        if (latestRecord.DueDate2 < DateTime.Now)
                        {
                            var disconnection = new Disconnection()
                            {
                                Barangay = customer.Barangay,
                                AcctNo = customer.AcctNo,
                                Name = String.Format("{0} {1} {2}", customer.Fname, customer.Mi, customer.Lname),
                                Address = string.Format("{0} {1} {2}, Magallanes Cavite ", customer.Barangay, customer.UnitNo, customer.Street),
                                Balance = latestRecord.Balance,
                                MeterNo = customer.MeterNo
                            };
                            disconnections.Add(disconnection);
                        }
                    }
                }
            }

            await _context.Database.ExecuteSqlRawAsync("DELETE FROM [Disconnection]");
            
            foreach (var disconnection in disconnections)
            {
                _context.Disconnections.Add(disconnection);
            }

            _context.SaveChanges();

            DisconnectionNoticeViewModel disconnectionVM = new();
            disconnectionVM.Barangays = _barangays;
            disconnectionVM.Disconnections = disconnections;

            return View(disconnectionVM);
        }

    }
}
