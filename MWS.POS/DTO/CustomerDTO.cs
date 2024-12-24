using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWS.POS.DTO
{
    public class CustomerDTO
    {
        public string AcctNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LogoPath { get; set; } = "\\Assets\\mws_seal.png";

    }
}
