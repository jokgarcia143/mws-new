using System;
using System.Collections.Generic;

namespace MWS.Web.Models
{
    public class WaterBillGeneratorViewModel
    {
        public Customer Customer { get; set; }      
        public WaterBill WaterBill { get; set; }
        public Wbcontrol Wbcontrol { get; set; }
        public int? Reading { get; set; } = 0;
        public int? Consumed { get; set; } = 0;
        public decimal? AmountBilled { get; set; } = 0;
        public decimal? CurrentBill { get; set; } = 0;
        public decimal? Others { get; set; } = 0;
        public string CurrDate { get; set; } = DateTime.Now.ToString("MM/dd/yyyy");
        public string Address { get; set; }
        public double? Discount { get; set; } = 0;    
        public decimal? Total { get; set; } = 0;
        public IEnumerable<Barangay> Barangays { get; set; }
        public int? BarangayId { get; set; }
    }
}
