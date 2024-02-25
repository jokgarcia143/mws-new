using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    [Table("Main")]
    public class Main
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AcctNo { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Amount { get; set; }
    }
}
