using System;
using System.Collections.Generic;

namespace MWS.Web.Models
{
    public class AddFeesViewModel
    {
        public int CustomerId { get; set; }
        public string AccountNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MeterNo { get; set; }
        public string AccountType { get; set; }
        public double? CurrentBalance { get; set; } = 0;
        public string TypeOfFee { get; set; }
        public string Others { get; set; }
        public double? Amount { get; set; } = 0;
        public double? NewBalance { get; set; } = 0;

    }
}
