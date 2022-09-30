using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Suppliers.DataModel
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("SERVER=DESKTOP-EDG1IN1\\SQLEXPRESS;DATABASE=eisensy_csbentprog;UID=eisensy_student;PWD=Benilde@2020;TRUSTSERVERCERTIFICATE=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SuppliersINV>().ToTable("SuppliersINV");
            modelBuilder.Entity<SuppliersINV>().Property(p => p.CompanyName).HasColumnType("nvarchar(100)");
            modelBuilder.Entity<SuppliersINV>().Property(p => p.Address).HasColumnType("nvarchar(200)");
            modelBuilder.Entity<SuppliersINV>().Property(p => p.Representative).HasColumnType("nvarchar(100)");
            modelBuilder.Entity<SuppliersINV>().Property(p => p.ContactNo).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<SuppliersINV>().Property(p => p.DateAdded).HasColumnType("DateTime");
            modelBuilder.Entity<SuppliersINV>().Property(p => p.DateModified).HasColumnType("DateTime");
        }

        public DbSet<SuppliersINV> SuppliersINV { get; set; }
    }
}
