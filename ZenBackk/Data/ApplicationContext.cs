using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<FinancialReport> FinancialReports { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shelf> Shelfs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany() // Si quieres que la Category tenga una lista de productos, usarías .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);


            // Fluent API Configurations for User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id); // Primary Key
                entity.Property(u => u.Username)
                      .IsRequired()
                      .HasMaxLength(100); // Username constraints

                entity.HasIndex(u => u.Username)
                      .IsUnique(); // Ensure Username is unique

                entity.Property(u => u.Password)
                      .IsRequired()
                      .HasMaxLength(100); // Password constraints
            });

            // RELACIÓN Sale -> SaleDetails
            modelBuilder.Entity<Sale>()
                .HasMany(s => s.SaleDetails)
                .WithOne(sd => sd.Sale)
                .HasForeignKey(sd => sd.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            // RELACIÓN Sale -> Payments
            modelBuilder.Entity<Sale>()
                .HasMany(s => s.Payments)
                .WithOne(p => p.Sale)
                .HasForeignKey(p => p.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            // RELACIÓN SaleDetail -> Product (ya existente)
            modelBuilder.Entity<SaleDetail>()
                .HasOne(sd => sd.Product)
                .WithMany()
                .HasForeignKey(sd => sd.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
