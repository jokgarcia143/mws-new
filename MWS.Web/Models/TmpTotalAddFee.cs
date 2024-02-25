using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    [Table("tmpTotalAddFees")]
    public class TmpTotalAddFee
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Barangay { get; set; }

        public int? Surcharge { get; set; }

        public int? ReconFee { get; set; }

        public int? TransferCharge { get; set; }
    }
}
