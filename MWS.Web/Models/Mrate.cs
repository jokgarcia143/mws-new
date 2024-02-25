using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Web.Models
{
    [Table("MRates")]
    public class Mrate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("METID")]
        public int Metid { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Bracket { get; set; }

        [UIHint("NumberTemplate")]
        [Required]
       
        public double? Minimum { get; set; }

        [UIHint("NumberTemplate")]
        [Required]
        [Column("11to30")]
        [DisplayName("11 to 30 Cu. M")]
        public double? _11to30 { get; set; }

        [UIHint("NumberTemplate")]
        [Required]
        [DisplayName("31 to 50 Cu. M")]
        [Column("31to50")]
        public double? _31to50 { get; set; }

        [UIHint("NumberTemplate")]
        [Required]
        [Column("51to70")]
        [DisplayName("51 to 70 Cu. M")]
        public double? _51to70 { get; set; }

        [UIHint("NumberTemplate")]
        [Required]
        [Column("71to90")]
        [DisplayName("71 to 90 Cu. M")]
        public double? _71to90 { get; set; }

        [UIHint("NumberTemplate")]
        [Required]
        [Column("91to110")]
        [DisplayName("91 to 110 Cu. M")]
        public double? _91to110 { get; set; }

        [UIHint("NumberTemplate")]
        [Required]
        [Column("111to130")]
        [DisplayName("111 to 130 Cu. M")]
        public double? _111to130 { get; set; }

        [UIHint("NumberTemplate")]
        [Required]
        [Column("131to150")]
        [DisplayName("131 to 150 Cu. M")]
        public double? _131to150 { get; set; }

        [UIHint("NumberTemplate")]
        [Required]
        [Column("151to170")]
        [DisplayName("151 to 170 Cu. M")]
        public double? _151to170 { get; set; }

        [UIHint("NumberTemplate")]
        [Required]
        [Column("171to190")]
        [DisplayName("171 to 190 Cu. M")]
        public double? _171to190 { get; set; }

        [UIHint("NumberTemplate")]
        [Required]
        [Column("191to10000")]
        [DisplayName("191 to 10000 Cu. M")]
        public double? _191to10000 { get; set; }
    }
}
