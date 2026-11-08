using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Models;

namespace UniversityCafeteria.Data;

public partial class CafeteriaDbContext : DbContext
{
    public CafeteriaDbContext(DbContextOptions<CafeteriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SupplyItem> SupplyItems { get; set; }

    public virtual DbSet<SupplyRequest> SupplyRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SupplyItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SupplyIt__3214EC07E6363574");

            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Priority).HasMaxLength(20);
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.SupplyRequest).WithMany(p => p.SupplyItems)
                .HasForeignKey(d => d.SupplyRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SupplyIte__Suppl__4E88ABD4");
        });

        modelBuilder.Entity<SupplyRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SupplyRe__3214EC0756D5AF23");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Confirmed");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
