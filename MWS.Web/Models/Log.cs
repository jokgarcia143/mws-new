using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    public class Log
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Office { get; set; }
    }
}
