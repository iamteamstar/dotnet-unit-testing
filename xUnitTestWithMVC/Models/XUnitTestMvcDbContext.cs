using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace xUnitTestWithMVC.Models;

public partial class XUnitTestMvcDbContext : DbContext
{
    public XUnitTestMvcDbContext()
    {
    }

    public XUnitTestMvcDbContext(DbContextOptions<XUnitTestMvcDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
