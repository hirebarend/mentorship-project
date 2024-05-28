using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProject.Models;
using MyProject.src.Domain.ValueObjects;
using MyProject.src.Models;

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
            .HasConversion(new ValueConverter<Price, decimal>(
            v => v.Value,
            v => new Price(v)));

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Product>()
            .Property(p => p.IsActive)
            .HasConversion(new ValueConverter<IsActive, bool>(
            v => v.Value,
            v => new IsActive(v)));

            modelBuilder.Entity<Product>()
                .Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                .Property(p => p.UpdatedAt)
                .ValueGeneratedNever();
        }
    }
}