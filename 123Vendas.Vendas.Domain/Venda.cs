using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _123Vendas.Domain;

[Table("Venda")]
public class Venda
{
    [Key] public Guid UID { get; set; }
    [Required] public int NumeroVenda { get; set; }
    [Required] public DateTime DataVenda { get; set; } = DateTime.Now;
    [Required] public Guid UIDCliente { get; set; }    
    [Required] public decimal ValorTotal { get; set; }
    [Required] public Guid UIDFilial { get; set; }    
    [Required] public int Status { get; set; }

    public virtual ICollection<Item> Itens { get; set; } = [];

    public virtual Cliente? Cliente { get; set; }
    public virtual Filial? Filial { get; set; }

    public class Configuration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasOne(x => x.Filial)
                .WithMany()
                .HasForeignKey(x => x.UIDFilial)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.UIDCliente)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Itens)
                    .WithOne(x => x.Venda)
                    .HasForeignKey(x => x.UIDVenda)
                    .HasPrincipalKey(x => x.UID)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }

}









