using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PRN_Project.Models;

#nullable disable

namespace PRN_Project.Models
{
    public partial class SWP_DB_FinalContext : DbContext
    {
        public SWP_DB_FinalContext()
        {
        }

        public SWP_DB_FinalContext(DbContextOptions<SWP_DB_FinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=SWP_DB_Final;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BonusPoint).HasColumnName("bonus_point");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(50)
                    .HasColumnName("Customer_type");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IsCus).HasColumnName("isCus");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IdAccount).HasColumnName("ID_account");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdAccount)
                    .HasConstraintName("FK_Bill_Account");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idcid);

                entity.ToTable("Category");

                entity.Property(e => e.Idcid)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCid");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Detail");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.IdProduct).HasColumnName("ID_product");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Bill)
                    .WithMany()
                    .HasForeignKey(d => d.BillId)
                    .HasConstraintName("FK_Detail_Bill");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Detail_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CateId).HasColumnName("cateID");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SellId).HasColumnName("sell_ID");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK_Product_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<PRN_Project.Models.BestSeller> BestSeller { get; set; }
    }
}
