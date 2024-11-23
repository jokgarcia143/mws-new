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
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace MWS.Web.Controllers
{
    [Authorize(Roles = "Administrator,Staff")]
    public class DisconnectionPDFController : Controller
    {

        private readonly MWSWebDBContext _context;
        private readonly IDocumentService _documentService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConverter _converter;

        public DisconnectionPDFController(MWSWebDBContext context, IDocumentService documentService, IWebHostEnvironment environment, IConverter converter)
        {
            _converter = converter;
            _context = context;
            _documentService = documentService;
            _webHostEnvironment = environment;
        }

        public async Task<IActionResult> DisconnectionPDF(int brgyId)
        {
            var brgy = _context.Barangays.Where(c => c.BrgyId == brgyId).FirstOrDefault();
            var disconnectionPDF = await _context.Disconnections.Where(c => c.Barangay == brgy.Brgy).ToListAsync();

            string htmlContent = "<a href='http://desktop-gdmbo8k:1010/ReportServerMWS/Pages/ReportViewer.aspx?%2fDisconnection&rs:Command=Render' target='_blank' rel='noopener noreferrer'>Go To Report Link</a>";
            return Content(htmlContent, "text/html");
            //return View(disconnectionPDF);
        }

        public async Task<IActionResult> DisconnectionReceivingPDF(int brgyId)
        {
            var brgy = _context.Barangays.Where(c => c.BrgyId == brgyId).FirstOrDefault();
            //
            ViewData["Barangay"] = brgy.Brgy;
            var disconnectionReceivingPDF = await _context.Disconnections.Where(c => c.Barangay == brgy.Brgy).ToListAsync();
            return View(disconnectionReceivingPDF);
        }
    }
}
