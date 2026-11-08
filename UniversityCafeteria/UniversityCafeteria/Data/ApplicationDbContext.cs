using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<UniversityCafeteria.Models.Category> Category { get; set; } = default!;

    public DbSet<UniversityCafeteria.Models.Product> Product { get; set; } = default!;

    public DbSet<UniversityCafeteria.Models.Supplier> Supplier { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UniversityCafeteria.Models.PurchaseOrderItem>()
            .HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
