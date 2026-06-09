using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIReiDaChapa.Models;
using Microsoft.EntityFrameworkCore;

namespace APIReiDaChapa.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Clientes> Clientes {get; set;}
        public DbSet<Pedidos> Pedidos {get; set;}
        public DbSet<Produtos> Produtos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedidos>()
                .HasOne(c => c.Clientes).WithMany()
                .HasForeignKey(c => c.IdClientes);
        }
    }
}