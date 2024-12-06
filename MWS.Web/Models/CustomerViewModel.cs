using System.Collections.Generic;

namespace MWS.Web.Models
{
    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Barangay> Barangays { get; set; }
        public int? BarangayId { get; set; }

        public string? TransType { get; set; }
    }
}
