using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Data
{
    public class TradeMarketDbContext : DbContext
    {
        public TradeMarketDbContext(DbContextOptions<TradeMarketDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptDetail> ReceiptsDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Person).WithOne().HasForeignKey<Customer>(e => e.PersonId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Category).WithMany(c => c.Products).HasForeignKey(e => e.ProductCategoryId);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Customer).WithMany(c => c.Receipts).HasForeignKey(e => e.CustomerId);
            });

            modelBuilder.Entity<ReceiptDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Product).WithMany(r => r.ReceiptDetails).HasForeignKey(e => e.ProductId);
                entity.HasOne(e => e.Receipt).WithMany(r => r.ReceiptDetails).HasForeignKey(e => e.ReceiptId);
                entity.Property(e => e.DiscountUnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
            });
        }

    }
}
