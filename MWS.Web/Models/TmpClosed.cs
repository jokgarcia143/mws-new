using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    [Table("tmpClosed")]
    public class TmpClosed
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AcctNo { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MeterNo { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string AcctType { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Status { get; set; }
    }
}
