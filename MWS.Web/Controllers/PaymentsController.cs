﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Pdf;
using System.IO;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;

namespace MWS.Web.Controllers
{
    [Authorize(Roles = "Cashier")]
    public class PaymentsController : Controller
    {
        private readonly MWSWebDBContext _context;
        //private readonly string format = "00000000000000000000.##";
        private readonly string dateFormat = "dd/MM/yyyy";
        private List<int> _years = new();
        private readonly IEnumerable<Barangay> _barangays;

        public PaymentsController(MWSWebDBContext context)
        {
            _context = context;
            _barangays = _context.Barangays.Distinct().AsEnumerable().OrderBy(c => c.Brgy);
            int year = DateTime.Now.Year;
            for (int i = year; i > 2000; i--)
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

            customerVM.Customers = await _context.Customers.Where(c => c.Status != "Closed" || c.Status != "T-Closed").OrderByDescending(c => c.Lname).ToListAsync();
            return View(customerVM);
            //var customers = await _context.Customers.ToListAsync();
            //return View(customers);
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
                barangay = _barangays.Where(b => b.BrgyId == barangayId).FirstOrDefault().Brgy;
            }
            else
            {
                //barangay = _barangays.Where(b => b.BrgyId == Convert.ToInt16(HttpContext.Session.GetInt32(_sessionBarangayId))).FirstOrDefault().Brgy;
            }
            customerVM.Customers = await _context.Customers.Where(c => c.Barangay == barangay && (c.Status != "Closed" || c.Status != "T-Closed")).ToListAsync();

            return View(customerVM);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var customer = await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
            var dateNow = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            var dailyTrans = await _context.DailyTrans.Where(dt => dt.TransDate == dateNow).ToListAsync();
            //CHECK O.R


            var waterbill = await _context.WaterBills.Where(c => c.AcctNo == customer.AcctNo).FirstOrDefaultAsync();

            var customersSummary = await _context.CustomersSummaries.OrderByDescending(c => c.PresDate2).Where(c => c.AcctNo == customer.AcctNo).FirstOrDefaultAsync();

            var fee = await _context.Fees.Where(c => c.SeniorDiscount != null).FirstOrDefaultAsync();

            if (customer.Senior == false)
            {
                TempData["Discount"] = 0.00;
            }
            else if (customer.Senior == true)
            {
                TempData["Discount"] = fee.SeniorDiscount;
            }

            TempData["EnvFee"] = fee.EnvironmentalFee;


            var transaction = new TransactionViewModel
            {
                Customer = customer,
                Address = string.Format("{0} {1} {2}", customer.Barangay, customer.UnitNo, customer.Street),
                DailyTransList = dailyTrans,
                CurrentTotalBalance = Convert.ToDecimal(waterbill.PrevBal2),
                WaterBillNo = customersSummary.WaterBillNo,
                Consumed = customersSummary.Consumed2
            };
            ViewBag.Years = _years;

            return View(transaction);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TransactionViewModel transactionVM)
        {
            var userName = HttpContext.Session.GetString("UNAME");
            if (userName == null)
            {
                //return Redirect("Error");
                return Redirect("/Identity/Account/Login");
            }

            //Check O.R
            //CustomersSummary customersSummary = new CustomersSummary();
            var checkOR = await _context.CustomersSummaries.Where(c => c.OfficialReceipt == transactionVM.OfficialReceipt).SingleOrDefaultAsync();
            if (checkOR != null)
            {
                //return RedirectToAction("About", "Home", new { id = 123 });
                TempData["OR"] = transactionVM.OfficialReceipt + " already exist";
                return RedirectToAction("Details", "Payments", new { id = transactionVM.Customer.Id });
            }

            var waterBill = await _context.WaterBills.Where(c => c.AcctNo == transactionVM.Customer.AcctNo).FirstOrDefaultAsync();
            var balance = (transactionVM.CurrentTotalBalance - transactionVM.AmountPaid).ToString();
            var transaction = await _context.TransactionTypes.Where(c => c.Code == transactionVM.Type).SingleOrDefaultAsync();

            if (transactionVM.Type == "3") 
            {
                //var _fee = GetFee(transactionVM.AmountPaid.ToString());
                var _fee = transactionVM.AmountPaid.ToString();
                string fee = _fee.Replace(",", "");
                transactionVM.AmountPaid = Convert.ToDecimal(fee);
            }
            

            ViewBag.Years = _years;

            if (ModelState.IsValid)
            {
                CustomersSummary customerSummary;



                customerSummary = new CustomersSummary
                {
                    Barangay = transactionVM.Customer.Barangay,
                    //Type = String.Format("{0} Payment", transactionVM.Type),
                    Type = transaction.TName,
                    AcctNo = transactionVM.Customer.AcctNo,
                    Name = "NA",
                    Address = "NA",
                    Month = String.Format("{0} / {1}", transactionVM.Month, transactionVM.Year),
                    WaterBillNo = transactionVM.WaterBillNo,
                    Reading = "NA",
                    Reading2 = 0.00m,
                    Consumed = "NA",
                    Consumed2 = 0.00m,
                    AmountBilled = "NA",
                    AmountBilled2 = 0.00m,
                    AmountPaid = transactionVM.AmountPaid.ToString(),
                    AmountPaid2 = transactionVM.AmountPaid,
                    OfficialReceipt = transactionVM.OfficialReceipt,
                    DatePaid = DateTime.Now.ToString(dateFormat),
                    DatePaid2 = Convert.ToDateTime("01/01/1900"),
                    Balance = balance,
                    Balance2 = 0.00m,
                    PrevDate = "NA",
                    PrevDate2 = Convert.ToDateTime("01/01/1900"),
                    PresDate = "NA",
                    PresDate2 = Convert.ToDateTime("01/01/1900"),
                    DueDate = "NA",
                    DueDate2 = Convert.ToDateTime("01/01/1900"),
                    CurrentBill = "NA",
                    CurrentBill2 = 0.00m,
                    Others = "NA",
                    Others2 = 0.00m,
                    PrevBal = "NA",
                    PrevBal2 = 0.00m,
                    PrevRead = "NA",
                    PrevRead2 = 0.00m,
                    MeterNo = transactionVM.Customer.MeterNo.Trim()
                };

                //UserName


                var dailyTransaction = new DailyTran
                {
                    AccountNo = transactionVM.Customer.AcctNo,
                    Amount = transactionVM.AmountPaid,
                    Cashier = userName,
                    TransDate = DateTime.Now.ToString(dateFormat),
                    Or = transactionVM.OfficialReceipt,
                    Payor = string.Format("{0} {1} {2}", transactionVM.Customer.Fname, transactionVM.Customer.Mi, transactionVM.Customer.Lname),
                    Particulars = String.Format("{0} Payment", transactionVM.Type)
                };

                waterBill.PrevBal = balance;
                waterBill.PrevDate = DateTime.Now.ToString(dateFormat);

                if (transactionVM.Type == "1")
                {
                    _context.WaterBills.Update(waterBill);
                }

                _context.CustomersSummaries.Add(customerSummary);
                _context.DailyTrans.Add(dailyTransaction);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction("Details", new { id = transactionVM.Customer.Id });
        }
        [HttpPost]
        public IActionResult PrintORPDF(TransactionViewModel transactionVM)
        {
            if (ModelState.IsValid)
            {
                var checkOR = _context.CustomersSummaries.Where(c => c.OfficialReceipt == transactionVM.OfficialReceipt).FirstOrDefault();

                if (checkOR != null)
                {
                    var customerSummary = new CustomersSummary
                    {
                        Name = string.Format("{0} {1}", transactionVM.Customer.Fname, transactionVM.Customer.Lname),
                        AcctNo = transactionVM.Customer.AcctNo,
                        Address = transactionVM.Address,
                        Month = String.Format("{0} / {1}", transactionVM.Month, transactionVM.Year),
                        MeterNo = transactionVM.Customer.MeterNo.ToString(),
                        Type = string.Format("{0} Payment", transactionVM.Type),
                        AmountPaid = transactionVM.AmountPaid.ToString(),
                        AmountPaid2 = Convert.ToDecimal(transactionVM.AmountPaid),
                        WaterBillNo = transactionVM.WaterBillNo
                    };

                    return View(customerSummary);
                }
                else
                {
                    var customerSummary = new CustomersSummary();
                    return View(customerSummary);
                }
            }

            return RedirectToAction("Details", new { id = transactionVM.Customer.Id });

        }
        [HttpPost]
        public IActionResult PrintORMatrix(TransactionViewModel transactionVM)
        {
            if (ModelState.IsValid)
            {
                var checkOR = _context.CustomersSummaries.Where(c => c.OfficialReceipt == transactionVM.OfficialReceipt).FirstOrDefault();

                if (checkOR != null)
                {
                    var customerSummary = new CustomersSummary
                    {
                        Name = string.Format("{0} {1}", transactionVM.Customer.Fname, transactionVM.Customer.Lname),
                        AcctNo = transactionVM.Customer.AcctNo,
                        Address = transactionVM.Address,
                        Month = String.Format("{0} / {1}", transactionVM.Month, transactionVM.Year),
                        MeterNo = transactionVM.Customer.MeterNo.ToString(),
                        Type = string.Format("{0} Payment", transactionVM.Type),
                        AmountPaid = transactionVM.AmountPaid.ToString(),
                        AmountPaid2 = Convert.ToDecimal(transactionVM.AmountPaid),
                        WaterBillNo = transactionVM.WaterBillNo
                    };

                    return View(customerSummary);
                }
                else
                {
                    var customerSummary = new CustomersSummary();
                    return View(customerSummary);
                }
            }

            return RedirectToAction("Details", new { id = transactionVM.Customer.Id });

        }
        [HttpGet] //selectedValue
        public string GetFee(string selectedValue)
        {
            var fee = _context.Fees.SingleOrDefault();
            string feeString = "N";
            if (fee != null)
            {
                if (selectedValue == "3")
                {
                    feeString = fee.ConnectionFee.ToString();
                }
                else if (selectedValue == "4")
                {
                    feeString = fee.ReconFee.ToString();
                }
                else if (selectedValue == "5")
                {
                    feeString = fee.ConnectionFee.ToString();
                }
                else if (selectedValue == "6")
                {
                    feeString = fee.Surcharge.ToString();
                }
                else if (selectedValue == "7")
                {
                    feeString = fee.TransferCharge.ToString();
                }
                else
                {
                    feeString = "N";
                }
            }
            return feeString;
        }
    }
}