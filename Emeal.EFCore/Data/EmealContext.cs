using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Emeal.EFCore.Models;

namespace Emeal.EFCore.Data
{
    public partial class EmealContext : DbContext
    {
        public EmealContext()
        {
        }

        public EmealContext(DbContextOptions<EmealContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<PaymentGateway> PaymentGateway { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-33O0MRR;Database=EmealOrder;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("Address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_User");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Instruction)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Order");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.BillingAddress).HasMaxLength(500);

                entity.Property(e => e.DeliveryAddress).HasMaxLength(500);

                entity.Property(e => e.DespatchTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentReference).HasMaxLength(100);

                entity.HasOne(d => d.OrderType)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderType");

                entity.HasOne(d => d.PaymentGateway)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PaymentGatewayId)
                    .HasConstraintName("FK_Order_PaymentGateway");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_PaymentStatus");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_PaymentType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<PaymentGateway>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Company");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
