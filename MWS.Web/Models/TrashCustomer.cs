using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    [Table("trashCustomers")]
    public class TrashCustomer
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("LName", TypeName = "nvarchar(100)")]
        public string Lname { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Fname { get; set; }

        [Column("MI", TypeName = "nvarchar(100)")]
        public string Mi { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string UnitNo { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Street { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Barangay { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AcctNo { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string MeterNo { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AcctType { get; set; }
    }
}
