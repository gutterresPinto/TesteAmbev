using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _123Vendas.Domain;

[Table("Cliente")]
public class Cliente
{
    [Key] public Guid UID { get; set; }
    [Required] public int NumeroCliente { get; set; }
    [Required] public required string Documento { get; set; } = "";
    [Required] public required string Nome { get; set; } = "";


    public class Configuration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
           
        }
    }
}
