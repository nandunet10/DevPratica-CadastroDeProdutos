using Microsoft.EntityFrameworkCore;
using ApiProduto.Models;

namespace ApiProduto.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }    
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                .HasMaxLength(80);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Estoque);

            modelBuilder.Entity<Produto>()
                .HasData(
                    new Produto { Id = 1, Nome = "Lapis", Preco = 1.10M, Estoque = 10 },
                    new Produto { Id = 2, Nome = "Borracha", Preco = 2.50M, Estoque = 8 },
                    new Produto { Id = 3, Nome = "Caneta Azul", Preco = 2.10M, Estoque = 12 },
                    new Produto { Id = 4, Nome = "Mochila", Preco = 100.0M, Estoque = 5 }

                );
        }

    }
}
