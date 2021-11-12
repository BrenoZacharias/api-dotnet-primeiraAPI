using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodosItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasKey(k => k.Id);
            modelBuilder.Entity<TodoItem>().Property(p => p.Id).IsRequired().UseIdentityColumn();

            modelBuilder.Entity<TodoItem>().Property(p => p.IsComplete).HasMaxLength(1)
                .IsRequired();

            modelBuilder.Entity<TodoItem>().Property(p => p.Name).HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<TodoItem>().Property(p => p.Secret).HasMaxLength(50)
                .IsRequired();

        }
    }
}
