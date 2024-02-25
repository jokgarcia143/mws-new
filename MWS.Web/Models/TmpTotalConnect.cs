using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MWS.Web.Models
{
    [Table("tmpTotalConnect")]
    public class TmpTotalConnect
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Barangay { get; set; }

        public int? Res { get; set; }
        public int? Com { get; set; }
        public int? Govt { get; set; }
    }
}
