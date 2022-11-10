using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Suppliers.DataModel
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-VMMN4I20\\SQLEXPRESS;Database=ENTPROG;Integrated Security=SSPI;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SuppliersINV>().ToTable("SuppliersINV");
            modelBuilder.Entity<SuppliersINV>().HasKey(p => p.SupplierID);
            modelBuilder.Entity<SuppliersINV>().Property(p => p.CompanyName).HasColumnType("nvarchar(100)");
            modelBuilder.Entity<SuppliersINV>().Property(p => p.Address).HasColumnType("nvarchar(200)");
            modelBuilder.Entity<SuppliersINV>().Property(p => p.Representative).HasColumnType("nvarchar(100)");
            modelBuilder.Entity<SuppliersINV>().Property(p => p.ContactNo).HasColumnType("nvarchar(50)");


            modelBuilder.Entity<Product>().ToTable("ProductsINV");
            modelBuilder.Entity<Product>().HasKey(p => p.ProductID);
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnType("nvarchar(200)");
            modelBuilder.Entity<Product>().Property(p => p.Unit).HasColumnType("nvarchar(50)");
        }

        public DbSet<SuppliersINV> SuppliersINV { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
