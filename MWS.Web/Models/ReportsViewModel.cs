using System.Collections.Generic;

namespace MWS.Web.Models
{
    public class ReportsViewModel
    {
        public IEnumerable<Barangay> Barangays { get; set; }
        public IEnumerable<string> Statuses { get; set; }
        public IEnumerable<string> AccountTypes { get; set; }
        public IEnumerable<Month> Months { get; set; }
        public string? BarangayId { get; set; }
        public string? CubicBarangayId { get; set; }
        public string? MonthId { get; set; }
        public string? MonthIdCubicBrgy { get; set; }
        public string? MonthIdCubicAcct { get; set; }
        
        public string? SelectedYear { get; set; }
        public string? YearIdCubicBrgy { get; set; }
        
        public string? SelectedBrgy { get; set; }

    }
}
