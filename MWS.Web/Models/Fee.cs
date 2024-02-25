using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    public class Fee
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Connection Fee")]
        [Column(TypeName ="nvarchar(255)")]
        public string ConnectionFee { get; set; }

        [Required]
        [DisplayName("Transfer Fee")]
        [Column(TypeName = "nvarchar(255)")]
        public string TransferCharge { get; set; }

        [Required]
        [DisplayName("Reconnection Fee")]
        [Column(TypeName = "nvarchar(255)")]
        public string ReconFee { get; set; }

        [Required]
        [DisplayName("Senior Discount (%)")]
        public double? SeniorDiscount { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Surcharge { get; set; }

        [Required]
        [DisplayName("Environmental Fee")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal EnvironmentalFee { get; set; } = 0.00m;
    }
}
