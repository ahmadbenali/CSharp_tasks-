using AcademyGraduation.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyGraduation.Data
{
    public class AcademyDbContext : DbContext
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // decimal precision for the price
            modelBuilder.Entity<Offer>()
                .Property(o => o.UnitPrice)
                .HasColumnType("decimal(18,2)");

            // one supplier has one offer
            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.Offer)
                .WithOne(o => o.Supplier)
                .HasForeignKey<Offer>(o => o.SupplierId);
        }
    }
}
