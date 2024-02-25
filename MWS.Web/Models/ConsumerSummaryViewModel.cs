using System.Collections.Generic;

namespace MWS.Web.Models
{
    public class ConsumerSummaryViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<CustomersSummary> CustomersSummaries { get; set; }
        public string Address { get; set; }
        public int TransactionNo { get; set; }
        public string NewMeterReading { get; set; }
        public int? LastTransactionNo { get; set; }
    }
}
