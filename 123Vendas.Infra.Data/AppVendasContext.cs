using Microsoft.EntityFrameworkCore;
using _123Vendas.Domain;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace _123Vendas.Infra.Data;

public class AppVendasContext :DbContext
{
    public AppVendasContext(DbContextOptions<AppVendasContext> options)
        :base(options) 
    { }

    public DbSet<Venda> Venda { get; set; } = null!;
    public DbSet<Cliente> Cliente { get; set; } = null!;
    public DbSet<Filial> Filial { get; set; } = null!;
    public DbSet<Item> Item { get; set; } = null!;
    public DbSet<Produto> Produto { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>()
            .Property(b => b.CodigoProduto)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Cliente>()
            .Property(c => c.NumeroCliente)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Venda>()
            .Property(v => v.NumeroVenda)
            .ValueGeneratedOnAdd();
    }

}