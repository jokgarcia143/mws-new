using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MWS.Web.Models
{
    [Table("DailyRep")]
    public class DailyRep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Dates { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string OrRange { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Payor { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Particulars { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Amount { get; set; }
    }
}
