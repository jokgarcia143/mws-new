using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MWS.Web.Models
{
    public partial class MWSWebContext : DbContext
    {
        public MWSWebContext()
        {
        }

        public MWSWebContext(DbContextOptions<MWSWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
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
        public virtual DbSet<Log1> Logs1 { get; set; }
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

        public virtual DbSet<TransactionType> TransactionTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=THEREALUSER;Database=MWSWeb4;User Id=mws;Password=London@12345;Trusted_Connection=false;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Barangay>(entity =>
            {
                entity.HasKey(e => e.BrgyId);

                entity.ToTable("Barangay");

                entity.Property(e => e.BrgyId).HasColumnName("brgyID");

                entity.Property(e => e.Brgy)
                    .HasMaxLength(255)
                    .HasColumnName("BRGY");

                entity.Property(e => e.Reading)
                    .HasMaxLength(10)
                    .HasColumnName("READING");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Number1).HasMaxLength(20);

                entity.Property(e => e.Number2).HasMaxLength(15);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.AcctNo, "IX_Customers_AcctNo")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.AcctType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Barangay)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("LName")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.MeterNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Mi)
                    .HasMaxLength(100)
                    .HasColumnName("MI");

                entity.Property(e => e.Senior)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Street).HasMaxLength(255);

                entity.Property(e => e.UnitNo).HasMaxLength(5);
            });

            modelBuilder.Entity<CustomersSummary>(entity =>
            {
                entity.ToTable("CustomersSummary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctNo).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.AmountBilled).HasMaxLength(50);

                entity.Property(e => e.AmountPaid).HasMaxLength(50);

                entity.Property(e => e.AmountPaid2)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Balance).HasMaxLength(50);

                entity.Property(e => e.Barangay).HasMaxLength(50);

                entity.Property(e => e.Consumed).HasMaxLength(50);

                entity.Property(e => e.CurrentBill)
                    .HasMaxLength(50)
                    .HasColumnName("currentBill");

                entity.Property(e => e.CurrentBill2)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DatePaid).HasMaxLength(50);

                entity.Property(e => e.DueDate)
                    .HasMaxLength(15)
                    .HasColumnName("dueDate");

                entity.Property(e => e.MeterNo).HasMaxLength(50);

                entity.Property(e => e.Month).HasMaxLength(50);

                entity.Property(e => e.MonthNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(75);

                entity.Property(e => e.OfficialReceipt).HasMaxLength(50);

                entity.Property(e => e.Others).HasMaxLength(50);

                entity.Property(e => e.PresDate)
                    .HasMaxLength(15)
                    .HasColumnName("presDate");

                entity.Property(e => e.PresDate2)
                    .HasColumnType("datetime")
                    .HasColumnName("presDate2");

                entity.Property(e => e.PrevBal)
                    .HasMaxLength(50)
                    .HasColumnName("prevBal");

                entity.Property(e => e.PrevDate)
                    .HasMaxLength(15)
                    .HasColumnName("prevDate");

                entity.Property(e => e.PrevRead)
                    .HasMaxLength(50)
                    .HasColumnName("prevRead");

                entity.Property(e => e.Reading).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.WaterBillNo).HasMaxLength(50);
            });

            modelBuilder.Entity<DailyRep>(entity =>
            {
                entity.ToTable("DailyRep");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasMaxLength(255);

                entity.Property(e => e.Dates).HasMaxLength(255);

                entity.Property(e => e.OrRange).HasMaxLength(255);

                entity.Property(e => e.Particulars).HasMaxLength(255);

                entity.Property(e => e.Payor).HasMaxLength(255);
            });

            modelBuilder.Entity<DailyTran>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountNo).HasMaxLength(255);

                entity.Property(e => e.Cashier).HasMaxLength(255);

                entity.Property(e => e.Or)
                    .HasMaxLength(255)
                    .HasColumnName("OR");

                entity.Property(e => e.Particulars).HasMaxLength(255);

                entity.Property(e => e.Payor).HasMaxLength(255);

                entity.Property(e => e.TransDate)
                    .HasMaxLength(255)
                    .HasColumnName("transDate");
            });

            modelBuilder.Entity<DailyTransQuery>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DailyTrans Query");

                entity.Property(e => e.Cashier).HasMaxLength(255);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<Disconnection>(entity =>
            {
                entity.ToTable("Disconnection");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctNo).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.Balance).HasMaxLength(50);

                entity.Property(e => e.Barangay).HasMaxLength(50);

                entity.Property(e => e.MeterNo).HasMaxLength(50);

                entity.Property(e => e.Month).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConnectionFee)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.ReconFee)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Surcharge)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.TransferCharge)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Log");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Office).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(15);

                entity.Property(e => e.UserName).HasMaxLength(20);
            });

            modelBuilder.Entity<Log1>(entity =>
            {
                entity.ToTable("Logs");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Office).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(15);

                entity.Property(e => e.UserName).HasMaxLength(20);
            });

            modelBuilder.Entity<Main>(entity =>
            {
                entity.ToTable("Main");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctNo).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Mrate>(entity =>
            {
                entity.HasKey(e => e.Metid);

                entity.ToTable("MRates");

                entity.Property(e => e.Metid).HasColumnName("METID");

                entity.Property(e => e.Bracket)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e._111to130).HasColumnName("111to130");

                entity.Property(e => e._11to30).HasColumnName("11to30");

                entity.Property(e => e._131to150).HasColumnName("131to150");

                entity.Property(e => e._151to170).HasColumnName("151to170");

                entity.Property(e => e._171to190).HasColumnName("171to190");

                entity.Property(e => e._191to10000).HasColumnName("191to10000");

                entity.Property(e => e._31to50).HasColumnName("31to50");

                entity.Property(e => e._51to70).HasColumnName("51to70");

                entity.Property(e => e._71to90).HasColumnName("71to90");

                entity.Property(e => e._91to110).HasColumnName("91to110");
            });

            modelBuilder.Entity<Prcontrol>(entity =>
            {
                entity.ToTable("PRControl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.No).HasMaxLength(255);
            });

            modelBuilder.Entity<TmpCc>(entity =>
            {
                entity.ToTable("tmpCC");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctNo).HasMaxLength(50);

                entity.Property(e => e.AcctType).HasMaxLength(50);

                entity.Property(e => e.MeterNo).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<TmpCcannual>(entity =>
            {
                entity.ToTable("tmpCCAnnual");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctType).HasMaxLength(50);

                entity.Property(e => e.Barangay).HasMaxLength(150);
            });

            modelBuilder.Entity<TmpClosed>(entity =>
            {
                entity.ToTable("tmpClosed");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctNo).HasMaxLength(50);

                entity.Property(e => e.AcctType).HasMaxLength(255);

                entity.Property(e => e.MeterNo).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Status).HasMaxLength(255);
            });

            modelBuilder.Entity<TmpMb>(entity =>
            {
                entity.ToTable("tmpMB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctNo).HasMaxLength(50);

                entity.Property(e => e.AcctType).HasMaxLength(50);

                entity.Property(e => e.MeterNo).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TmpMr>(entity =>
            {
                entity.ToTable("tmpMR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctNo).HasMaxLength(50);

                entity.Property(e => e.MeterNo).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.PrevRead).HasColumnName("prevRead");

                entity.Property(e => e.Status).HasMaxLength(255);
            });

            modelBuilder.Entity<TmpTotalAddFee>(entity =>
            {
                entity.ToTable("tmpTotalAddFees");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barangay).HasMaxLength(150);
            });

            modelBuilder.Entity<TmpTotalConnect>(entity =>
            {
                entity.ToTable("tmpTotalConnect");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barangay).HasMaxLength(150);
            });

            modelBuilder.Entity<TrashCustomer>(entity =>
            {
                entity.ToTable("trashCustomers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctNo).HasMaxLength(50);

                entity.Property(e => e.AcctType).HasMaxLength(50);

                entity.Property(e => e.Barangay).HasMaxLength(50);

                entity.Property(e => e.Fname).HasMaxLength(100);

                entity.Property(e => e.Lname)
                    .HasMaxLength(100)
                    .HasColumnName("LName");

                entity.Property(e => e.MeterNo).HasMaxLength(15);

                entity.Property(e => e.Mi)
                    .HasMaxLength(100)
                    .HasColumnName("MI");

                entity.Property(e => e.Street).HasMaxLength(255);

                entity.Property(e => e.UnitNo).HasMaxLength(5);
            });

            modelBuilder.Entity<TrashWbill>(entity =>
            {
                entity.ToTable("trashWbill");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctNo).HasMaxLength(10);

                entity.Property(e => e.PrevBal)
                    .HasMaxLength(50)
                    .HasColumnName("prevBal");

                entity.Property(e => e.PrevDate)
                    .HasMaxLength(15)
                    .HasColumnName("prevDate");

                entity.Property(e => e.PrevRead)
                    .HasMaxLength(15)
                    .HasColumnName("prevRead");
            });

            modelBuilder.Entity<WaterBill>(entity =>
            {
                entity.ToTable("WaterBill");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcctNo).HasMaxLength(50);

                entity.Property(e => e.PrevBal)
                    .HasMaxLength(50)
                    .HasColumnName("prevBal");

                entity.Property(e => e.PrevDate)
                    .HasMaxLength(15)
                    .HasColumnName("prevDate");

                entity.Property(e => e.PrevRead)
                    .HasMaxLength(15)
                    .HasColumnName("prevRead");
            });

            modelBuilder.Entity<Wbcontrol>(entity =>
            {
                entity.ToTable("WBcontrol");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.No).HasMaxLength(255);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("TransactionTypes");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.TName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
