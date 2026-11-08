using Microsoft.EntityFrameworkCore;

using UniversityCafeteria.Models;

namespace UniversityCafeteria.Data
{
    public class EmployeesDBContext : DbContext
    {
        public EmployeesDBContext(DbContextOptions<EmployeesDBContext> options)
       : base(options) { }
        public DbSet<Product> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product> Suppliers { get; set; }
        public DbSet<Product> PurchaseOrderes { get; set; }
        public DbSet<Product> PurchaseOrderItemes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseOrderItem>()
                .HasOne(i => i.Product)
                .WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
