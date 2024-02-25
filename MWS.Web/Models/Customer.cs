using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    [Index(nameof(AcctNo), IsUnique = true)]
    public class Customer
    {       

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [Column("LName", TypeName = "nvarchar(100)")]
        public string Lname { get; set; }

        [Required]
        [DisplayName("First Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string Fname { get; set; }

        [DisplayName("Middle Name")]
        [Column("MI", TypeName = "nvarchar(100)")]
        public string Mi { get; set; }

        [DisplayName("Unit #")]
        [Column(TypeName = "nvarchar(5)")]
        public string UnitNo { get; set; }
   
        [Column(TypeName = "nvarchar(255)")]
        public string Street { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Barangay { get; set; }

        [Required]
        [DisplayName("Account Number")]
        [Column(TypeName = "nvarchar(50)")]
        public string AcctNo { get; set; }

        [Required]
        [DisplayName("Meter Number")]
        [Column(TypeName = "nvarchar(15)")]
        public string MeterNo { get; set; }

        [Required]
        [DisplayName("Account Type")]
        [Column(TypeName = "nvarchar(50)")]
        public string AcctType { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Status { get; set; }

        [Column(TypeName = "bit")]
        public bool Senior { get; set; } = false;
    }
}
