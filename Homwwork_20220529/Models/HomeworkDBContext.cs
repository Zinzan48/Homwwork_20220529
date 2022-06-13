using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Homework_EntityFramework.Models
{
    public partial class HomeworkDBContext : DbContext
    {
        public HomeworkDBContext()
        {
        }

        public HomeworkDBContext(DbContextOptions<HomeworkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;
        public virtual DbSet<TblFamily> TblFamilies { get; set; } = null!;
        public virtual DbSet<TblFood> TblFoods { get; set; } = null!;
        public virtual DbSet<TblFoodOrder> TblFoodOrders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.ToTable("TblCustomer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Money).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblFamily>(entity =>
            {
                entity.HasKey(e => e.FamilyId);

                entity.ToTable("TblFamily");

                entity.Property(e => e.FamilyId).HasColumnName("FamilyID");

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.NickName).HasMaxLength(15);

                entity.Property(e => e.Title).HasMaxLength(10);
            });

            modelBuilder.Entity<TblFood>(entity =>
            {
                entity.ToTable("TblFood");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Style).HasMaxLength(50);
            });

            modelBuilder.Entity<TblFoodOrder>(entity =>
            {
                entity.ToTable("TblFoodOrder");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.OrderDatetime).HasColumnType("datetime");

                entity.Property(e => e.PaidDateTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
