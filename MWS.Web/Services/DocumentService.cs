using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using MWS.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MWS.Web.Services
{
    public class DocumentService: IDocumentService
    {
        private readonly IConverter _converter;
        private readonly IRazorRendererHelper _razorRendererHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DocumentService(IConverter converter, IRazorRendererHelper razorRendererHelper, IWebHostEnvironment environment)
        {
            _converter = converter;
            _razorRendererHelper = razorRendererHelper;
            _webHostEnvironment = environment;
        }


        public byte[] GeneratePDF(string htmlContent)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 18, Bottom = 18 },
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" },
                //HeaderSettings = { FontSize = 10, Right = "Page [page] of [toPage]", Line = true },
                //FooterSettings = { FontSize = 8, Center = "PDF demo from JeminPro", Line = true },
            };

            var htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings },
            };

            return _converter.Convert(htmlToPdfDocument);
        }

        //public byte[] GeneratePdfFromRazorViewList<TModel>(TModel models, string partialName)
        //{
        //    var htmlContent = _razorRendererHelper.RenderPartialToString(partialName, models);

        //    return GeneratePdf(htmlContent);
        //}
    }
}
