using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    public class DailyTran
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("transDate", TypeName = "nvarchar(255)")]
        public string TransDate { get; set; }

        [Column("OR", TypeName = "nvarchar(255)")]
        public string Or { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Payor { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Particulars { get; set; }
        public decimal Discount { get; set; } = 0.00m;
        public decimal EnvironmentalFee { get; set; } = 0.00m;

        public decimal Amount { get; set; } = 0.00m;

        [Column(TypeName = "nvarchar(255)")]
        public string AccountNo { get; set; }

        [StringLength(255)]
        public string Cashier { get; set; }
    }
}
