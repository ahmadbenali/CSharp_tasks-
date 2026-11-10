using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<UniversityCafeteria.Models.Category> Category { get; set; } = default!;

    public DbSet<UniversityCafeteria.Models.Product> Product { get; set; } = default!;

    public DbSet<UniversityCafeteria.Models.Supplier> Supplier { get; set; } = default!;

    public DbSet<SupplyRequest> SupplyRequests { get; set; } = default!;

    public DbSet<RequestItem> RequestItems { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UniversityCafeteria.Models.PurchaseOrderItem>()
            .HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // SupplyItem belongs to the old CafeteriaDbContext, so it is not created here
        modelBuilder.Entity<SupplyRequest>().Ignore(r => r.SupplyItems);
        modelBuilder.Ignore<SupplyItem>();

        modelBuilder.Entity<SupplyRequest>().Property(r => r.TotalPrice).HasColumnType("decimal(10, 2)");
        modelBuilder.Entity<RequestItem>().Property(i => i.Price).HasColumnType("decimal(10, 2)");

        // Restrict: a product that is used in a request cannot be deleted by mistake
        modelBuilder.Entity<RequestItem>()
            .HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
