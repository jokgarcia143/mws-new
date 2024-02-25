using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    [Table("Barangay")]
    public class Barangay
    {
        [Key]
        [Column("brgyID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrgyId { get; set; }

        [Column("BRGY",TypeName = "nvarchar(255)")]
        public string Brgy { get; set; }

        [Column("READING",TypeName ="nvarchar(10)")]
        public string Reading { get; set; }
    }
}
