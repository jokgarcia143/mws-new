using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace MWS.Web.Models
{
    [Table("CustomersSummary")]
    public class CustomersSummary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Barangay { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Type { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string TypeNo { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AcctNo { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Month { get; set; }

        [Column(TypeName = "int")]
        public int MonthNo { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string WaterBillNo { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Reading { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Reading2 { get; set; } = 0.00m;

        [Column(TypeName = "nvarchar(50)")]
        public string Consumed { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Consumed2 { get; set; } = 0.00m;


        [Column(TypeName = "nvarchar(50)")]
        public string AmountBilled { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountBilled2 { get; set; } = 0.00m;


        [Column(TypeName = "nvarchar(50)")]
        public string AmountPaid { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountPaid2 { get; set; } = 0.00m;

        [Column(TypeName = "nvarchar(50)")]
        public string OfficialReceipt { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string DatePaid { get; set; }

        [Column("DatePaid2", TypeName = "datetime")]
        public DateTime DatePaid2 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Balance { get; set; }

        [Column("Balance2", TypeName = "decimal(18,2)")]
        public decimal Balance2 { get; set; } = 0.00m;

        [Column("prevDate", TypeName = "nvarchar(15)")]
        public string PrevDate { get; set; }
        [Column("prevDate2", TypeName = "datetime")]
        public DateTime PrevDate2 { get; set; }

        [Column("presDate", TypeName = "nvarchar(15)")]
        public string PresDate { get; set; }

        [Column("presDate2", TypeName = "datetime")]
        public DateTime PresDate2 { get; set; }

        [Column("dueDate", TypeName = "nvarchar(15)")]
        public string DueDate { get; set; }

        [Column("dueDate2", TypeName = "datetime")]
        public DateTime DueDate2 { get; set; }

        [Column("currentBill", TypeName = "nvarchar(50)")]
        public string CurrentBill { get; set; }

        [Column("currentBill2", TypeName = "decimal(18,2)")]
        public decimal CurrentBill2 { get; set; } = 0.00m;

        [Column(TypeName = "nvarchar(50)")]
        public string Others { get; set; }
        [Column("Others2", TypeName = "decimal(18,2)")]
        public decimal Others2 { get; set; } = 0.00m;

        [Column("prevBal", TypeName = "nvarchar(50)")]
        public string PrevBal { get; set; }
        [Column("prevBal2", TypeName = "decimal(18,2)")]
        public decimal PrevBal2 { get; set; } = 0.00m;

        [Column("prevRead", TypeName = "nvarchar(50)")]
        public string PrevRead { get; set; }

        [Column("prevRead2", TypeName = "decimal(18,2)")]
        public decimal PrevRead2 { get; set; } = 0.00m;

        [Column(TypeName = "nvarchar(50)")]
        public string MeterNo { get; set; }
    }
}
