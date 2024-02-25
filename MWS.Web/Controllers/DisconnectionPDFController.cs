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
            return View(disconnectionPDF);
        }

        public async Task<IActionResult> DisconnectionReceivingPDF()
        {
            var disconnectionReceivingPDF = await _context.Disconnections.ToListAsync();
            return View(disconnectionReceivingPDF);
        }
    }
}
