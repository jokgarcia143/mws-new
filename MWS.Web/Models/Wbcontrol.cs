using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace MWS.Web.Models
{
    [Table("WBcontrol")]
    public class Wbcontrol
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Water Bill No.")]
        [Column(TypeName = "nvarchar(255)")]
        public string No { get; set; }
    }
}
