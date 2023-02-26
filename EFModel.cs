using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WarehouseTask
{
    public partial class EFModel : DbContext
    {
        public EFModel()
            : base("name=EFModel")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Store> Product_Store { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.WebSite)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MeasuringUnit)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Permissions)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.ProductCode);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_Store)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.WebSite)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.SupplierID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Permissions1)
                .WithRequired(e => e.Supplier1)
                .HasForeignKey(e => e.SupplierID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Manager)
                .IsUnicode(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Warehouse)
                .HasForeignKey(e => e.StoreID);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Product_Store)
                .WithRequired(e => e.Warehouse)
                .HasForeignKey(e => e.StorageID)
                .WillCascadeOnDelete(false);
        }
    }
}
