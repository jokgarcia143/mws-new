using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MWS.Web.Areas.Identity.Data;
using MWS.Web.Models;

namespace MWS.Web.Models
{
    public class MWSWebDBContext : DbContext
    {
        public MWSWebDBContext(DbContextOptions<MWSWebDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TransactionType> TransactionTypes  { get; set; }
        public virtual DbSet<Barangay> Barangays { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomersSummary> CustomersSummaries { get; set; }
        public virtual DbSet<DailyRep> DailyReps { get; set; }
        public virtual DbSet<DailyTran> DailyTrans { get; set; }
        public virtual DbSet<DailyTransQuery> DailyTransQueries { get; set; }
        public virtual DbSet<Disconnection> Disconnections { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Main> Mains { get; set; }
        public virtual DbSet<Mrate> Mrates { get; set; }
        public virtual DbSet<Prcontrol> Prcontrols { get; set; }
        public virtual DbSet<TmpCc> TmpCcs { get; set; }
        public virtual DbSet<TmpCcannual> TmpCcannuals { get; set; }
        public virtual DbSet<TmpClosed> TmpCloseds { get; set; }
        public virtual DbSet<TmpMb> TmpMbs { get; set; }
        public virtual DbSet<TmpMr> TmpMrs { get; set; }
        public virtual DbSet<TmpTotalAddFee> TmpTotalAddFees { get; set; }
        public virtual DbSet<TmpTotalConnect> TmpTotalConnects { get; set; }
        public virtual DbSet<TrashCustomer> TrashCustomers { get; set; }
        public virtual DbSet<TrashWbill> TrashWbills { get; set; }
        public virtual DbSet<WaterBill> WaterBills { get; set; }
        public virtual DbSet<Wbcontrol> Wbcontrols { get; set; }
        //public virtual DbSet<ProjectRole> ProjectRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.AcctNo)
                .IsUnique();
        }

    }
}
