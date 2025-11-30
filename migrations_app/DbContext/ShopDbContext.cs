using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace migrations_app
{
    public partial class ShopDbContext : DbContext
    {

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WIN-8G40ARFN4JP\DANGERNN;Database=Shop_PV41;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Устанавливаем отношение "один ко многим" между заказами и продуктами
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany();

            // Устанавливаем связь "один к одному" между заказами и клиентами
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany()
                .HasForeignKey(o => o.ClientId);
        }
    }
}

