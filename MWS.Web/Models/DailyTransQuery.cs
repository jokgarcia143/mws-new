using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace MWS.Web.Models
{
    [Keyless]
    [Table("DailyTrans Query")]
    public class DailyTransQuery
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Cashier { get; set; }
    }
}
