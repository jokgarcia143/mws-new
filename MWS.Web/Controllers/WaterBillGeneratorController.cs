using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Pdf;
using System.IO;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using MWS.Web.Helpers;

namespace MWS.Web.Controllers
{
    [Authorize(Roles = "Administrator,Staff")]
    public class WaterBillGeneratorController : Controller
    {
        private readonly MWSWebDBContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hostingEnvironment;
        private readonly string format = "00000000000000000000.##";
        private List<int> _years = new();
        private readonly IEnumerable<Barangay> _barangays;
        private readonly string _dateformat = "dd/MMM/yyyy";

        public WaterBillGeneratorController(MWSWebDBContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _barangays = _context.Barangays.Distinct().AsEnumerable().OrderBy(c => c.Brgy);
            _hostingEnvironment = hostingEnvironment;
            int year = DateTime.Now.Year;
            for (int i = year; i < 2000; i--)
            {
                _years.Add(i);
            }
        }

        public async Task<IActionResult> Index()
        {
            CustomerViewModel customerVM = new()
            {
                Customers = new List<Customer>(),
                Barangays = _barangays
            };

            customerVM.Customers = await _context.Customers.Where(c => c.Status != "Closed" || c.Status != "T-Closed").ToListAsync();
            return View(customerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int barangayId)
        {

            string barangay = string.Empty;
            CustomerViewModel customerVM = new()
            {
                Customers = new List<Customer>(),
                Barangays = _barangays,
                BarangayId = barangayId
            };

            if (barangayId != 0)
            {
                //HttpContext.Session.SetInt32(_sessionBarangayId, Convert.ToInt32(barangayId));
                barangay = _barangays.Where(b => b.BrgyId == barangayId).FirstOrDefault().Brgy;
            }
            else
            {
                //barangay = _barangays.Where(b => b.BrgyId == Convert.ToInt16(HttpContext.Session.GetInt32(_sessionBarangayId))).FirstOrDefault().Brgy;
            }
            customerVM.Customers = await _context.Customers.Where(c => c.Barangay == barangay && (c.Status != "Closed" || c.Status != "T-Closed")).ToListAsync();

            return View(customerVM);
        }

        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            DailyTran dailyTran = await _context.DailyTrans.Where(c => c.Id == Id).FirstOrDefaultAsync();
            Customer customer = await _context.Customers.Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (customer.Street == "") { customer.Street = "#"; }
            WaterBill waterbill = await _context.WaterBills.Where(c => c.AcctNo == customer.AcctNo).FirstOrDefaultAsync();
            Mrate mrate = await _context.Mrates.Where(m => m.Bracket == customer.AcctType).FirstOrDefaultAsync();
            Fee fee = await _context.Fees.FirstOrDefaultAsync();

            //Get WaterBill No
            var waterBillControl = _context.Wbcontrols.OrderByDescending(c => c.Id).FirstOrDefault();
            var wbConvert = Convert.ToDouble(waterBillControl.No);
            var newWB = wbConvert + 1;
            int dgCount = Convert.ToInt32(newWB.ToString().Length);
            int zero = 20 - dgCount;
            string addZero = new string('0', zero);
            string finalWB = addZero.ToString() + newWB.ToString();
            TempData["WaterBillNo"] = finalWB.ToString().Trim();

            int latestRecord = _context.Wbcontrols.Count() + 1;
            var wbcontrol = new Wbcontrol { No = latestRecord.ToString(format) };
            var waterBillGeneratorVM = new WaterBillGeneratorViewModel
            {
                CurrDate = DateTime.Now.ToString("dd/MMM/yyyy"),
                Address = string.Format("{0} {1} {2}", customer.Barangay, customer.UnitNo, customer.Street)
            };
            waterbill ??= new WaterBill
            {
                AcctNo = customer.AcctNo,
                PrevBal = "0",
                PrevRead = 0.ToString()
            };
            if (waterbill.PrevBal == "NA" || waterbill.PrevBal == "")
            {
                waterbill.PrevBal = "0";
            } 
            waterBillGeneratorVM.WaterBill = waterbill;
            //waterBillGeneratorVM.Wbcontrol = wbcontrol;
            waterBillGeneratorVM.Customer = customer;
            waterBillGeneratorVM.Discount = fee.SeniorDiscount;

            ViewBag.Barangay = await _context.Barangays.Distinct().ToListAsync();
            ViewBag.Minimum = mrate.Minimum;
            ViewBag.First = mrate._11to30;
            ViewBag.Second = mrate._31to50;
            ViewBag.Third = mrate._51to70;
            ViewBag.Fourth = mrate._71to90;
            ViewBag.Fifth = mrate._91to110;
            ViewBag.Sixth = mrate._111to130;
            ViewBag.Seventh = mrate._131to150;
            ViewBag.Eighth = mrate._151to170;
            ViewBag.Ninth = mrate._171to190;
            ViewBag.Tenth = mrate._191to10000;

            if (waterBillGeneratorVM == null)
            {
                return NotFound();
            }
            return View(waterBillGeneratorVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(WaterBillGeneratorViewModel waterBillGeneratorVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DateConverter dateConverter = new DateConverter();

                    var defaultDT = dateConverter.ConvertStringToDate("31/1/1753 12:00:00 AM");
                    var prevDT = dateConverter.ConvertStringToDate(waterBillGeneratorVM.WaterBill.PrevDate);
                    var currentDT = dateConverter.ConvertStringToDate(DateTime.UtcNow.ToString());

                    //Get WaterBill No
                    var finalWB = CheckWaterBillNo(waterBillGeneratorVM.Wbcontrol.No);                    

                    var lastrecord = await _context.CustomersSummaries.Where(c => c.AcctNo == waterBillGeneratorVM.Customer.AcctNo).OrderByDescending(cs => cs.Id).Select(x => x.PrevBal).LastOrDefaultAsync();
                    var balance = (waterBillGeneratorVM.CurrentBill + waterBillGeneratorVM.Others + Convert.ToDecimal(waterBillGeneratorVM.WaterBill.PrevBal)).ToString();
                    if (lastrecord == null)
                    {
                        //lastrecord = new CustomersSummary();
                        lastrecord = "0.00";
                    }
                    var customerSummary = new CustomersSummary
                    {
                        Barangay = waterBillGeneratorVM.Customer.Barangay,
                        Type = SystemEnum.TransType.T2.GetDescription(),
                        AcctNo = waterBillGeneratorVM.Customer.AcctNo,
                        Name = string.Format("{0} {1} {2}", waterBillGeneratorVM.Customer.Fname, waterBillGeneratorVM.Customer.Mi, waterBillGeneratorVM.Customer.Lname),
                        Address = string.Format("{0} {1} {2}", waterBillGeneratorVM.Customer.Barangay, waterBillGeneratorVM.Customer.UnitNo, waterBillGeneratorVM.Customer.Street),
                        Month = string.Format("{0} / {1}", DateTime.Now.ToString("MMMM"), DateTime.Now.ToString("yyyy")),
                        MonthNo = DateTime.Now.Month,
                        WaterBillNo = finalWB,
                        Reading = waterBillGeneratorVM.Reading.ToString(),
                        Reading2 = Convert.ToDecimal(waterBillGeneratorVM.Reading.ToString()),
                        Consumed = waterBillGeneratorVM.Consumed.ToString(),
                        Consumed2 = Convert.ToDecimal(waterBillGeneratorVM.Consumed.ToString()),
                        AmountBilled = (Convert.ToDecimal(waterBillGeneratorVM.CurrentBill) + Convert.ToDecimal(waterBillGeneratorVM.Others)).ToString(),
                        AmountBilled2 = (Convert.ToDecimal(waterBillGeneratorVM.CurrentBill) + Convert.ToDecimal(waterBillGeneratorVM.Others)),
                        AmountPaid = "0.00",
                        AmountPaid2 = 0.00m,
                        OfficialReceipt = "NA",
                        DatePaid = currentDT.ToString(),
                        DatePaid2 = Convert.ToDateTime(currentDT),
                        Balance = balance,
                        Balance2 = Convert.ToDecimal(balance),
                        PrevDate = prevDT.ToString(),
                        PrevDate2 = Convert.ToDateTime(prevDT.ToString()),
                        PresDate = defaultDT.ToString(),
                        PresDate2 = defaultDT,
                        DueDate = defaultDT.ToString(),
                        DueDate2 = defaultDT,
                        CurrentBill = waterBillGeneratorVM.CurrentBill.ToString(),
                        CurrentBill2 = Convert.ToDecimal(waterBillGeneratorVM.CurrentBill),
                        Others = waterBillGeneratorVM.Others.ToString(),
                        Others2 = Convert.ToDecimal(waterBillGeneratorVM.Others),
                        PrevBal = lastrecord,
                        PrevRead = waterBillGeneratorVM.Reading.ToString(),
                        PrevRead2 = Convert.ToDecimal(waterBillGeneratorVM.Reading),
                        MeterNo = waterBillGeneratorVM.Customer.MeterNo
                    };
                    var waterBill = await _context.WaterBills.Where(c => c.AcctNo == waterBillGeneratorVM.Customer.AcctNo).FirstOrDefaultAsync();

                    var currentBillDT = dateConverter.ConvertStringToDate(waterBillGeneratorVM.CurrDate);

                    waterBill ??= new WaterBill();
                    waterBill.AcctNo = waterBillGeneratorVM.Customer.AcctNo;
                    waterBill.PrevBal2 = Convert.ToDecimal(balance);
                    waterBill.PrevRead = waterBillGeneratorVM.Reading.ToString();
                    waterBill.PrevRead2 = Convert.ToDecimal(waterBillGeneratorVM.Reading.ToString());
                    waterBill.PrevDate = currentBillDT.ToString();
                    waterBill.PrevDate2 = currentBillDT;

                    waterBillGeneratorVM.Wbcontrol.No = finalWB.ToString();

                    _context.WaterBills.Update(waterBill);
                    await _context.CustomersSummaries.AddAsync(customerSummary);
                    await _context.Wbcontrols.AddAsync(waterBillGeneratorVM.Wbcontrol);
                    await _context.SaveChangesAsync();

                    //Water Bill Format
                    return RedirectToAction(nameof(Index));
                    //return RedirectToAction("Update", new { Id = waterBill.AcctNo });
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
            }

            return View(waterBillGeneratorVM);
        }

        public IActionResult Sample()
        {
            var options = new HtmlLoadOptions();
            var pdfDocument = new Document($@"{_hostingEnvironment.ContentRootPath}\ReportTemplates\reportsample.html", options);
            using (var stream = new MemoryStream())
            {
                pdfDocument.Save(stream);
                stream.Position = 0;
                stream.Seek(0, SeekOrigin.Begin);
                var bytes = stream.ToArray();
                return File(bytes, "application/pdf", "file.pdf");
            }
        }

        private string CheckWaterBillNo(string wb)
        {
            var checkWB = _context.Wbcontrols.Where(c => c.No == wb).FirstOrDefault();

            if (checkWB != null) {
                var waterBillControl = _context.Wbcontrols.OrderByDescending(c => c.Id).FirstOrDefault();
                var wbConvert = Convert.ToDouble(waterBillControl.No);
                var newWB = wbConvert + 1;
                int dgCount = Convert.ToInt32(newWB.ToString().Length);
                int zero = 20 - dgCount;
                string addZero = new string('0', zero);
                wb = addZero.ToString() + newWB.ToString();
            }
                      

            return wb;
        }

    }
}
