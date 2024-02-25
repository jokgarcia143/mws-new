using Aspose.Pdf;

namespace MWS.Web.Models.ViewModels
{
    public class NewConnectionsVM
    {
        public int Id { get; set; }
        public string Baranggay { get; set; } = "";
        public int Residential { get; set; } = 0;
        public int Commercial { get; set; } = 0;
        public int Government { get; set; } = 0;
    }
}
