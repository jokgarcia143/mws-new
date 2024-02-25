using System.Collections.Generic;

namespace MWS.Web.Models
{
    public class ControlPanelViewModel
    {
        public Mrate Mrate { get; set; }
        public IEnumerable<Mrate> Mrates { get; set; }
        public Fee Fee { get; set; }
    }
}
