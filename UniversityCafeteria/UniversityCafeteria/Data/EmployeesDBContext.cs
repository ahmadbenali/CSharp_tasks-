using Microsoft.EntityFrameworkCore;

using UniversityCafeteria.Models;

namespace UniversityCafeteria.Data
{
    public class EmployeesDBContext : DbContext
    {
        public EmployeesDBContext(DbContextOptions<EmployeesDBContext> options)
       : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrderes { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItemes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<order> Orders { get; set; }

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
