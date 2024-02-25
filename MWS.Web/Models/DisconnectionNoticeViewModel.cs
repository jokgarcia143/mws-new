using System.Collections.Generic;

namespace MWS.Web.Models
{
    public class DisconnectionNoticeViewModel
    {

        public IEnumerable<Disconnection> Disconnections { get; set; }
        public IEnumerable<Barangay> Barangays { get; set; }
        public int? BarangayId { get; set; }
    }
}
