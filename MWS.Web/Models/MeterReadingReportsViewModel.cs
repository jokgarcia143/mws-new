using System.Collections.Generic;

namespace MWS.Web.Models
{
    public class MeterReadingReportsViewModel
    {
        public IEnumerable<MeterReadingReports> CustomerMeterReadings { get; set; }
        public string Barangay { get; set; }
    }
}