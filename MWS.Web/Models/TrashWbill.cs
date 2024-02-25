using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    [Table("trashWbill")]
    public class TrashWbill
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string AcctNo { get; set; }

        [Column("prevRead", TypeName = "nvarchar(15)")]
        public string PrevRead { get; set; }

        [Column("prevDate", TypeName = "nvarchar(15)")]
        public string PrevDate { get; set; }

        [Column("prevBal", TypeName = "nvarchar(50)")]
        public string PrevBal { get; set; }
    }
}
