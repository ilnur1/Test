using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dis1.Models
{
    public partial class Fara1Context : DbContext
    {
        //надо будет передалать как нибудь контекст с нуля, но это потом
        public Fara1Context()
        {
        }

        public Fara1Context(DbContextOptions<Fara1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Shablon> Shablon { get; set; }
        //connectionString лучше прописовать в config
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Fara1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { //ты же создал модель БД на Entity, зачем стрингами прописываешь названия таблиц?
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Cc);

                entity.Property(e => e.Cc)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyAdress)
                    .HasColumnName("company_adress")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyDescription)
                    .HasColumnName("company_description")
                    .HasMaxLength(250);

                entity.Property(e => e.CompanyInn)
                    .HasColumnName("Company_inn")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyLogin)
                    .IsRequired()
                    .HasColumnName("company_login")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("Company_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyPas)
                    .IsRequired()
                    .HasColumnName("company_pas")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyPhone)
                    .HasColumnName("company_phone")
                    .HasMaxLength(50);

                entity.Property(e => e.Family).HasMaxLength(50);

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Lasttname)
                    .HasColumnName("lasttname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Friends>(entity =>
            {
                entity.HasKey(e => e.Cf);

                entity.Property(e => e.Cf)
                    .HasColumnName("cf")
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FriendOne)
                    .HasColumnName("friend_one")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.FriendTwo)
                    .HasColumnName("friend_two")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("decimal(1, 0)");

                entity.HasOne(d => d.FriendOneNavigation)
                    .WithMany(p => p.FriendsFriendOneNavigation)
                    .HasForeignKey(d => d.FriendOne)
                    .HasConstraintName("FK__Friends__friend___36B12243");

                entity.HasOne(d => d.FriendTwoNavigation)
                    .WithMany(p => p.FriendsFriendTwoNavigation)
                    .HasForeignKey(d => d.FriendTwo)
                    .HasConstraintName("FK__Friends__friend___37A5467C");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.Cr);

                entity.Property(e => e.Cr)
                    .HasColumnName("cr")
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cc)
                    .HasColumnName("cc")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.ReportCustomer)
                    .IsRequired()
                    .HasColumnName("report_customer")
                    .HasMaxLength(50);

                entity.Property(e => e.ReportDate)
                    .HasColumnName("report_date")
                    .HasColumnType("date");

                entity.Property(e => e.ReportName)
                    .HasColumnName("report_name")
                    .HasMaxLength(30);

                entity.Property(e => e.ReportStatus)
                    .IsRequired()
                    .HasColumnName("report_status")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReportWay)
                    .IsRequired()
                    .HasColumnName("report_way")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CcNavigation)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.Cc)
                    .HasConstraintName("FK__Report__cc__2C3393D0");
            });

            modelBuilder.Entity<Shablon>(entity =>
            {
                entity.HasKey(e => e.Cs);

                entity.Property(e => e.Cs)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cc)
                    .HasColumnName("cc")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.ShablonAgent)
                    .HasColumnName("shablon_agent")
                    .HasMaxLength(50);

                entity.Property(e => e.ShablonName)
                    .IsRequired()
                    .HasColumnName("Shablon_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ShablonOrder)
                    .HasColumnName("shablon_order")
                    .HasMaxLength(50);

                entity.Property(e => e.ShablonPosition)
                    .IsRequired()
                    .HasColumnName("Shablon_position")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CcNavigation)
                    .WithMany(p => p.Shablon)
                    .HasForeignKey(d => d.Cc)
                    .HasConstraintName("FK__Shablon__cc__29572725");
            });
        }
    }
}
