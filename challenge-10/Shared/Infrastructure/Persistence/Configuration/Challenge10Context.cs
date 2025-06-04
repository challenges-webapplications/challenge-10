using System;
using Microsoft.EntityFrameworkCore;
using challenge_10.Operations.Domain.Models.Entities;
namespace challenge_10.Shared.Infrastructure.Persistence.Configuration;

public class Challenge10Context(DbContextOptions options) : DbContext(options)
{
        public DbSet<Operation> Operations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Operation Entity Configuration
            builder.Entity<Operation>(entity =>
            {
                entity.ToTable("Operation");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Description)
                    .IsRequired()
                    .HasMaxLength(500);
                entity.Property(c => c.Completed)
                    .IsRequired();
                entity.Property(c => c.CompletedDate)
                    .IsRequired();
                
                entity.HasIndex(c => c.Name)
                    .IsUnique(); // Ensures uniqueness
            });

        }
}
