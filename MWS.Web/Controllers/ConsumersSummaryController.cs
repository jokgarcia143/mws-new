using Aspose.Pdf;
using Aspose.Pdf.Operators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MWS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.Adapters.Entities;

namespace MWS.Web.Controllers
{
    [Authorize]
    public class ConsumersSummaryController : Controller
    {
        private readonly MWSWebDBContext _context;
        private readonly string _dateformat = "dd/mm/yyyy";
        private readonly IEnumerable<Barangay> _barangays;

        public ConsumersSummaryController(MWSWebDBContext context)
        {
            _context = context;
            _barangays = _context.Barangays.Distinct().AsEnumerable().OrderBy(c => c.Brgy);
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
                //HttpContext.Session.SetInt32(_sessionBarangayId, Convert.ToInt32(barangayId));
                barangay = _barangays.Where(b => b.BrgyId == barangayId).FirstOrDefault().Brgy;
            }
            else
            {
                //barangay = _barangays.Where(b => b.BrgyId == Convert.ToInt16(HttpContext.Session.GetInt32(_sessionBarangayId))).FirstOrDefault().Brgy;
            }
            customerVM.Customers = await _context.Customers.Where(c => c.Barangay == barangay).ToListAsync();

            return View(customerVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id, DateTime? fromDate, DateTime? toDate)
        {
            Customer customer = await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();

            IEnumerable<CustomersSummary> customersSummaries = new List<CustomersSummary>();

            var lastWaterBillIssue = new CustomersSummary();


            if (fromDate.HasValue && toDate.HasValue)
            {
                customersSummaries = await _context.CustomersSummaries.Where(cs => cs.AcctNo == customer.AcctNo && cs.DatePaid2 >= fromDate && cs.DatePaid2 <= toDate && cs.AmountPaid2 > 0).OrderBy(cs => cs.Id).ToListAsync();
                lastWaterBillIssue = customersSummaries.Where(c => c.Type == "WATER BILL ISSUE" && c.DatePaid2 >= fromDate && c.DatePaid2 <= toDate && c.AmountPaid2 > 0).FirstOrDefault();
                if(lastWaterBillIssue == null)
                {
                    lastWaterBillIssue = customersSummaries.Where(c => c.Type == "WATER BILL ISSUE").LastOrDefault();
                }
            }
            else
            {
                customersSummaries = await _context.CustomersSummaries.Where(cs => cs.AcctNo == customer.AcctNo).OrderBy(cs => cs.Id).ToListAsync();
                lastWaterBillIssue = customersSummaries.Where(c => c.Type == "WATER BILL ISSUE").LastOrDefault();
            }
            
            
            var consumerSummaryViewModel = new ConsumerSummaryViewModel();
            consumerSummaryViewModel.Customer = customer;
            consumerSummaryViewModel.Address = string.Format("{0} {1} {2}", customer.Barangay, customer.UnitNo, customer.Street);
            consumerSummaryViewModel.CustomersSummaries = customersSummaries;
            if (lastWaterBillIssue != null) 
            {
                consumerSummaryViewModel.LastTransactionNo = lastWaterBillIssue.Id;
            }
            return View(consumerSummaryViewModel);

        }


        [HttpPost]
        public async Task<IActionResult> UpdateMeterReading(string command)
        {
            string updateRequest = HttpContext.Request.Form["update-meter"];
            string updateTransNo = HttpContext.Request.Form["update-transno"];
            CustomersSummary customerSummary = await _context.CustomersSummaries.Where(c => c.Id == Convert.ToInt32(updateTransNo)).FirstOrDefaultAsync();
            Customer customer = await _context.Customers.Where(c => c.AcctNo == customerSummary.AcctNo).FirstOrDefaultAsync();

            if (command == "save")
            {
                Mrate mrate = await _context.Mrates.Where(m => m.Bracket == customer.AcctType).FirstOrDefaultAsync();
                Fee fee = await _context.Fees.FirstOrDefaultAsync();
                double consumed = Convert.ToDouble(updateRequest) - Convert.ToDouble(customerSummary.PrevRead2);

                double? subtotal = WaterBillCompute(consumed , mrate);
                double? discount = 0;

                if (customer.Senior)
                {
                    discount = subtotal * (fee.SeniorDiscount);
                    subtotal = subtotal - discount;
                }

                customerSummary.Reading2 = Convert.ToDecimal(updateRequest);
                customerSummary.Consumed2 = Convert.ToDecimal(consumed);
                customerSummary.CurrentBill2 = Convert.ToDecimal(subtotal);
                customerSummary.AmountBilled2 = Convert.ToDecimal((subtotal + Convert.ToDouble(customerSummary.Others)));
                customerSummary.Balance2 = Convert.ToDecimal((subtotal + Convert.ToDouble(customerSummary.PrevBal) + Convert.ToDouble(customerSummary.Others)).ToString());

                _context.CustomersSummaries.Update(customerSummary);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = customer.Id });
            }

            return NotFound();

           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Customer customer)
        {
            var _customer = await _context.Customers.Where(c => c.Id == customer.Id).FirstOrDefaultAsync();
            var _waterbill = await _context.WaterBills.Where(c => c.AcctNo == _customer.AcctNo).FirstOrDefaultAsync();
            var lastrecord = await _context.CustomersSummaries.Where(c => c.AcctNo == _customer.AcctNo).OrderBy(cs => cs.Id).LastOrDefaultAsync();
            _customer.MeterNo = customer.MeterNo;
            if (_waterbill != null)
            {
                _waterbill.PrevRead = "0";
                _waterbill.PrevDate = DateTime.Now.ToString(_dateformat);
                _waterbill.PrevBal = lastrecord.Balance;
            }
            var customerSummary = new CustomersSummary
            {
                Barangay = _customer.Barangay,
                Type = "CHANGE METER NO",
                AcctNo = _customer.AcctNo,
                Name = "NA",
                Address = "NA",
                Month = "NA",
                WaterBillNo = "NA",
                Reading = "0",
                Consumed = "NA",
                AmountBilled = "NA",
                AmountPaid = "NA",
                OfficialReceipt = "NA",
                DatePaid = DateTime.Now.ToString(_dateformat),
                Balance = lastrecord.Balance,
                PrevDate = "NA",
                PresDate = "NA",
                DueDate = "NA",
                CurrentBill = "NA",
                Others = "NA",
                PrevBal = "NA",
                PrevRead = "NA",
                MeterNo = customer.MeterNo

            };

            _context.Customers.Update(_customer);
            _context.WaterBills.Update(_waterbill);
            _context.CustomersSummaries.Add(customerSummary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> AddFee(int? id)
        {
            var customer = await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (customer != null)
            {
                var accountRecord = await _context.WaterBills.Where(w => w.AcctNo == customer.AcctNo).FirstOrDefaultAsync();
                var addFeesViewModel = new AddFeesViewModel
                {
                    CustomerId = customer.Id,
                    AccountNo = customer.AcctNo,
                    Name = string.Format("{0} {1} {2}", customer.Fname, customer.Mi, customer.Lname),
                    Address = string.Format("{0} {1} {2}", customer.Barangay, customer.UnitNo, customer.Street),
                    MeterNo = customer.MeterNo,
                    AccountType = customer.AcctType,
                    CurrentBalance = Convert.ToDouble(accountRecord.PrevBal)
                };

                return View(addFeesViewModel);
            }

            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> AddNewFee(AddFeesViewModel addFeesVM)
        {

            if (ModelState.IsValid)
            {
                var waterBill = await _context.WaterBills.Where(c => c.AcctNo == addFeesVM.AccountNo).FirstOrDefaultAsync();
                var customer = await _context.Customers.Where(c => c.AcctNo == addFeesVM.AccountNo).FirstOrDefaultAsync();

                if (addFeesVM.TypeOfFee == "Others")
                {
                    addFeesVM.TypeOfFee = String.Format("Others - {0}", addFeesVM.Others);
                }

                var customerSummary = new CustomersSummary
                {
                    Barangay = customer.Barangay,
                    Type = addFeesVM.TypeOfFee,
                    AcctNo = addFeesVM.AccountNo,
                    Name = string.Format("{0} {1} {2}", customer.Fname, customer.Mi, customer.Lname),
                    Address = addFeesVM.Address,
                    Month = "NA",
                    WaterBillNo = "NA",
                    Reading = "NA",
                    Consumed = "NA",
                    AmountBilled = addFeesVM.Amount.ToString(),
                    AmountPaid = "UNPAID",
                    OfficialReceipt = "NA",
                    DatePaid = "NA",
                    Balance = addFeesVM.NewBalance.ToString(),
                    PrevDate = "NA",
                    PresDate = DateTime.Today.ToString(_dateformat),
                    DueDate = "NA",
                    CurrentBill = "NA",
                    Others = "NA",
                    PrevBal = "NA",
                    PrevRead = "NA",
                    MeterNo = addFeesVM.MeterNo
                };

                waterBill.PrevBal = addFeesVM.NewBalance.ToString();

                _context.WaterBills.Update(waterBill);
                _context.CustomersSummaries.Add(customerSummary);

                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { id = addFeesVM.CustomerId });

            }
            return NotFound();

        }

        [HttpGet]
        public async Task<IActionResult> ReprintWaterBillPDF(string acctNo)
        {
            var customerSummary = await _context.CustomersSummaries.OrderByDescending(c => c.PrevDate2).Where(c => c.AcctNo == acctNo.Trim()).FirstOrDefaultAsync();

            if (customerSummary != null)
            {
                if(customerSummary.PrevRead2 > 0 || customerSummary.PrevRead2 > 0)
                {
                    customerSummary.DueDate2 = DateTime.Now.AddDays(15);
                    _context.SaveChanges();
                }
                else
                {
                    return RedirectToAction("Index", "WaterBillGenerator");
                }
            }
            return View(customerSummary);
        }

        [HttpGet]
        public async Task<IActionResult> PrintSummaryPDF(string acctNo)
        {
            var customerSummaries = await _context.CustomersSummaries.Where(c => c.AcctNo == acctNo).ToListAsync();
            return View(customerSummaries);
        }

        public double? WaterBillCompute(double consumed, Mrate mrate)
        {
            double? remainingConsumed = consumed - 10;
            double? rate = 0;

            // minimum 1-10 consumed
            double? subtotal = mrate.Minimum; 

            // if consumed is between 11 and 30
            if (consumed > 10 && consumed < 31) 
            {
                rate = mrate._11to30 * remainingConsumed;
                return (subtotal + rate);
            }
            else if (consumed > 30)
            {
                rate = mrate._11to30 * 20;
                remainingConsumed = consumed - 30;
                subtotal = subtotal + rate;
            }

            // if consumed is between 31 and 50
            if (consumed > 30 && consumed < 51)
            {
                rate = (mrate._31to50 * remainingConsumed);
                return (subtotal + rate);
            }
            else if (consumed > 50)
            {
                rate = mrate._31to50 * 20;
                remainingConsumed = consumed - 50;
                subtotal = subtotal + rate;
            }

            // if consumed is between 51 and 70
            if (consumed > 50 && consumed < 71)
            {
                rate = (mrate._51to70 * remainingConsumed);
                return (subtotal + rate);
            }
            else if (consumed > 70)
            {
                rate = mrate._51to70 * 20;
                remainingConsumed = consumed - 70;
                subtotal = subtotal + rate;
            }

            // if consumed is between 71 and 90
            if (consumed > 70 && consumed < 91)
            {
                rate = (mrate._71to90 * remainingConsumed);
                return (subtotal + rate);
            }
            else if (consumed > 90)
            {
                rate = mrate._71to90 * 20;
                remainingConsumed = consumed - 90;
                subtotal = subtotal + rate;
            }

            // if consumed is between 91 and 110
            if (consumed > 90 && consumed < 111)
            {
                rate = (mrate._91to110 * remainingConsumed);
                return (subtotal + rate);
            }
            else if (consumed > 90)
            {
                rate = mrate._91to110 * 20;
                remainingConsumed = consumed - 110;
                subtotal = subtotal + rate;
            }

            // if consumed is between 111 and 130
            if (consumed > 110 && consumed < 131)
            {
                rate = (mrate._111to130 * remainingConsumed);
                return (subtotal + rate);
            }
            else if (consumed > 130)
            {
                rate = mrate._111to130 * 20;
                remainingConsumed = consumed - 130;
                subtotal = subtotal + rate;
            }

            // if consumed is between 131 and 150
            if (consumed > 130 && consumed < 151)
            {
                rate = (mrate._131to150 * remainingConsumed);
                return (subtotal + rate);
            }
            else if (consumed > 150)
            {
                rate = mrate._131to150 * 20;
                remainingConsumed = consumed - 150;
                subtotal = subtotal + rate;
            }

            // if consumed is between 151 and 171
            if (consumed > 150 && consumed < 171)
            {
                rate = (mrate._151to170 * remainingConsumed);
                return (subtotal + rate);
            }
            else if (consumed > 170)
            {
                rate = mrate._151to170 * 20;
                remainingConsumed = consumed - 170;
                subtotal = subtotal + rate;
            }

            // if consumed is between 171 and 190
            if (consumed > 170 && consumed < 191)
            {
                rate = (mrate._171to190 * remainingConsumed);
                return (subtotal + rate);
            }
            else if (consumed > 190)
            {
                rate = mrate._171to190 * 20;
                remainingConsumed = consumed - 190;
                subtotal = subtotal + rate;
            }

            // if consumed over 190
            if (consumed > 190)
            {
                rate = (mrate._191to10000 * remainingConsumed);
                return (subtotal + rate);
            }           
          
            return subtotal;
        }


    }
}
