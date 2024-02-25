using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Web.Helpers;
using MWS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWS.Web.Controllers
{
    [Authorize(Roles = "Administrator,Staff")]
    public class ConsumersData : Controller
    {
        private readonly MWSWebDBContext _context;
        private readonly IEnumerable<Barangay> _barangays;
        private readonly IEnumerable<string> _brackets;
        private string _sessionBarangayId;

        public ConsumersData(MWSWebDBContext context)
        {
            _context = context;
            _barangays = _context.Barangays.Distinct().AsEnumerable().OrderBy(c => c.Brgy);
            _brackets = _context.Mrates.Select(b => b.Bracket).Distinct();
            _sessionBarangayId = String.Empty;

        }

        public async Task<IActionResult> Index()
        {
            CustomerViewModel customerVM = new()
            {
                Customers = new List<Customer>(),
                Barangays = _barangays
            };
            customerVM.Customers = await _context.Customers.OrderByDescending(c => c.Lname).ToListAsync();
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
               HttpContext.Session.SetInt32(_sessionBarangayId, Convert.ToInt32(barangayId));
               barangay = _barangays.Where(b => b.BrgyId ==  barangayId).FirstOrDefault().Brgy;             
            } else
            {
                barangay = _barangays.Where(b => b.BrgyId == Convert.ToInt16(HttpContext.Session.GetInt32(_sessionBarangayId))).FirstOrDefault().Brgy;               
            }
            customerVM.Customers = await _context.Customers.Where(c => c.Barangay == barangay).ToListAsync();

            return View(customerVM);
        }

        public IActionResult Create()
        {
            ViewBag.Brackets = _brackets;
            ViewBag.Barangay = _barangays;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            //Check Account No Duplicate
            var checkAcctNo = await _context.Customers.Where(c => c.AcctNo == customer.AcctNo).SingleOrDefaultAsync();

            if(checkAcctNo != null)
            {
                TempData["AcctNoCheck"] = customer.AcctNo + " already exists!";
                return RedirectToAction("Create","ConsumersData");
            }

            //Check Duplicate Meter
            var checkMeter = await _context.Customers.Where(c => c.MeterNo == customer.MeterNo).SingleOrDefaultAsync();
            if(checkMeter != null)
            {
                TempData["MeterCheck"] = customer.MeterNo + " already exists!";
                return RedirectToAction("Create", "ConsumersData");
            }

            ViewBag.Brackets = _brackets;
            ViewBag.Barangay = _barangays;

            DateConverter dateConverter = new DateConverter();

            var dtNow = dateConverter.ConvertStringToDate(DateTime.UtcNow.ToString());
            var defaultDT = dateConverter.ConvertStringToDate("01/01/1900 12:00:00 AM");

            if (ModelState.IsValid)
            {
                var prevBalance = _context.Fees.Select(f => f.ConnectionFee).FirstOrDefaultAsync();
                var waterbill = new WaterBill
                {
                    AcctNo = customer.AcctNo,
                    PrevRead = "0",
                    PrevRead2 = 0.00m,
                    PrevDate = dtNow.ToString(),
                    PrevDate2 = dtNow,
                    PrevBal = prevBalance.Result.ToString(),
                    PrevBal2 = 0.00m
                };
                var initialSummary = new CustomersSummary
                {
                    Barangay = customer.Barangay.Trim(),
                    Type = "NEW CONNECTION",
                    AcctNo = customer.AcctNo.Trim(),
                    Name = "NA",
                    Address = "NA",
                    Month = "NA",
                    WaterBillNo = "NA",
                    Reading = "NA",
                    Reading2 = 0.00m,
                    Consumed = "NA",
                    Consumed2 = 0.00m,
                    AmountBilled = "NA",
                    AmountBilled2 = 0.00m,
                    AmountPaid = "UNPAID",
                    AmountPaid2 = 0.00m,
                    OfficialReceipt = "NA",
                    DatePaid = defaultDT.ToString(),
                    DatePaid2 = defaultDT,
                    Balance = prevBalance.Result.ToString().Trim(),
                    Balance2 = Convert.ToDecimal(prevBalance.Result),
                    PrevDate = "NA",
                    PrevDate2 = defaultDT,
                    PresDate = "NA",
                    PresDate2 = defaultDT,
                    DueDate = "NA",
                    DueDate2 = defaultDT,
                    CurrentBill = "NA",
                    CurrentBill2 = 0.00m,
                    Others = "NA",
                    PrevBal = "NA",
                    PrevBal2 = 0.00m,
                    PrevRead = "NA",
                    PrevRead2 = 0.00m,
                    MeterNo = customer.MeterNo.Trim()
                };
                _context.Customers.Add(customer);
                _context.WaterBills.Add(waterbill);
                _context.CustomersSummaries.Add(initialSummary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int? Id)
        {
            ViewBag.Brackets = _brackets;
            ViewBag.Barangay = _barangays;
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var customer = await _context.Customers.Where(c => c.Id == Id).FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Customer customer)
        {
            ViewBag.Brackets = _brackets;
            ViewBag.Barangay = _barangays;
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var customer = await _context.Customers.FindAsync(id);

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
