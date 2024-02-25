using System.Collections.Generic;

namespace MWS.Web.Models
{
    public class TransactionViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<DailyTran> DailyTransList { get; set; }
        public string Address { get; set; }
        public decimal CurrentTotalBalance { get; set; } = 0.00m;
        public decimal AmountPaid { get; set; } = 0.00m;
        public decimal Consumed { get; set; } = 0.00m;
        public string Type { get; set; }
        public string WaterBillNo { get; set; } = "NA";
        public string OfficialReceipt { get; set; } = "";
        public string Month { get; set; }
        public string Year { get; set; }

    }
}

