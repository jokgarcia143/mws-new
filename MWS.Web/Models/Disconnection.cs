using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    [Table("Disconnection")]
    public class Disconnection
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Barangay { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AcctNo { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Month { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Balance { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MeterNo { get; set; }

    }
}
