using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    [Table("WaterBill")]
    public class WaterBill
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Account Number")]
        [Column(TypeName = "nvarchar(50)")]
        public string AcctNo { get; set; }

        [DisplayName("Previous Reading")]
        [Column("prevRead", TypeName = "nvarchar(15)")]    
        public string PrevRead { get; set; }

        [DisplayName("Previous Reading")]
        [Column("prevRead2", TypeName = "decimal(18,2)")]
        public decimal PrevRead2 { get; set; } = 0.00m;

        [DisplayName("Previous Date")]
        [Column("prevDate", TypeName = "nvarchar(15)")]
        public string PrevDate { get; set; }

        [DisplayName("Previous Date")]
        [Column("prevDate2", TypeName = "datetime")]
        public DateTime PrevDate2 { get; set; }

        [DisplayName("Previous Balance")]
        [Column("prevBal", TypeName = "nvarchar(50)")]
        public string PrevBal { get; set; }

        [DisplayName("Previous Balance")]
        [Column("prevBal2", TypeName = "decimal(18,2)")]
        public decimal PrevBal2 { get; set; } = 0.00m;
    }
}
