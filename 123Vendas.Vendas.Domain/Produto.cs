using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace _123Vendas.Domain;

[Table("Produto")]
public class Produto
{
    [Key] public Guid UID { get; set; }
    [Required] public int CodigoProduto { get; set; }
    [Required] public required string Nome { get; set; }
    [Required] public decimal Valor { get; set; }

    public class Configuration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

        }
    }
}
