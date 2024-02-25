using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    [Table("tmpCCAnnual")]
    public class TmpCcannual
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Barangay { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AcctType { get; set; }

        public int? Jan { get; set; }
        public int? Feb { get; set; }
        public int? Mar { get; set; }
        public int? Apr { get; set; }
        public int? May { get; set; }
        public int? Jun { get; set; }
        public int? Jul { get; set; }
        public int? Aug { get; set; }
        public int? Sep { get; set; }
        public int? Oct { get; set; }
        public int? Nov { get; set; }
        public int? Dec { get; set; }
    }
}
