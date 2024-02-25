using MWS.Web.Controllers;
using System.Collections.Generic;

namespace MWS.Web.Models
{
    public class ClosedConsumersReportsViewModel
    {
        public List<Customer> Consumers { get; set; }
        public string Barangay { get; set; }
    }
}