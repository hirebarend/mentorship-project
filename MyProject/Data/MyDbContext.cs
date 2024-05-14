using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject.Data
{
   public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(p => p.Description)
            .HasMaxLength(500);

        modelBuilder.Entity<Product>()
            .Property(p => p.IsActive)
            .HasDefaultValue(true);

        modelBuilder.Entity<Product>()
            .Property(p => p.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Product>()
            .Property(p => p.UpdatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnUpdate();
    }
}
}