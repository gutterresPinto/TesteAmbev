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

    public virtual DbSet<Venda> Venda { get; set; } 
    public virtual DbSet<Cliente> Cliente { get; set; }
    public virtual DbSet<Filial> Filial { get; set; }
    public virtual DbSet<Item> Item { get; set; } 
    public virtual DbSet<Produto> Produto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Venda.Configuration());
        modelBuilder.ApplyConfiguration(new Cliente.Configuration());
        modelBuilder.ApplyConfiguration(new Filial.Configuration());
        modelBuilder.ApplyConfiguration(new Item.Configuration());
        modelBuilder.ApplyConfiguration(new Produto.Configuration());




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