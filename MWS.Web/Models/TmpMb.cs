using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MWS.Web.Models
{
    [Table("tmpMB")]
    public class TmpMb
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AcctType { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AcctNo { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MeterNo { get; set; }

        public double? AmountBilled { get; set; }
    }
}
