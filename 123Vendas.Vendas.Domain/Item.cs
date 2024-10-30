using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _123Vendas.Domain;

[Table("Item")]
public class Item
{
    [Key] public Guid UID { get; set; }
    [Required] public Guid UIDVenda { get; set; }
    [Required] public Guid UIDProduto { get; set; }        
    [Required] public int Quantidade { get; set; }
    [Required] public decimal Desconto { get; set; }
    [Required] public decimal ValorItem { get; set; }

    public Produto? Produto { get; set; }
    public Venda? Venda { get; set; }

    public class Configuration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {

            builder.HasOne(x => x.Venda)
                .WithMany()
                .HasForeignKey(x => x.UIDVenda)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.UIDProduto)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
